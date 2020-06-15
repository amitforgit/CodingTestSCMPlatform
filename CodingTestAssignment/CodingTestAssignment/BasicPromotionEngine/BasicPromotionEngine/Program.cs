using BasicPromotionEngine.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BasicPromotionEngine
{
    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Initial Sku defined
            var listSku = InitialSetup.InitializeSku();            
            Dictionary<string, int> skuUnit = new Dictionary<string, int>();

            Console.WriteLine("Enter the scenario with comma separated value eg: 3A,2B,1C");
            Console.WriteLine("Make sure to enter combination values with % specifiier eg: 1C%1D");

            string scenario = Console.ReadLine();

            // Get all the values from the config file
            foreach (string value in scenario.Split(","))
            {
                if (!value.Contains("%"))
                {
                    skuUnit.Add(value.Substring(value.Length - 1), Convert.ToInt32(value.Substring(0, value.Length - 1)));
                }
                else
                {
                    // In case of value contains % then set it 0 and get it from calculation
                    skuUnit.Add(value, 0);
                }
            }

            // Get the price from the CalculatePromotion 
            double totalPrice = CalculatePromotion(skuUnit, listSku);
            Console.WriteLine("Price for the Listed Items are:" + totalPrice);

            Console.ReadLine();
        }

        /// <summary>
        /// CalculatePromotion
        /// </summary>
        /// <param name="scenarioUser"></param>
        /// <param name="skuList"></param>
        /// <returns></returns>
        public static int CalculatePromotion(Dictionary<string, int> scenarioUser, List<SkuSetup> skuList)
        {
            int price = 0;
            List<string> strPrmotionList = new List<string>();

            Dictionary<string, int> dictValue = new Dictionary<string, int>();

            // Get All prmotion list from configuration
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    dictValue.Add(Convert.ToString(key), Convert.ToInt32(appSettings[key]));
                }
            }

            // Logic for calculating the alogorithm
            price = CalculatePricingAlgorithm(scenarioUser, skuList, price, dictValue);
            return price;
        }

        /// <summary>
        /// CalculatePricingAlgorithm
        /// </summary>
        /// <param name="scenarioUser"></param>
        /// <param name="skuList"></param>
        /// <param name="price"></param>
        /// <param name="dictValue"></param>
        /// <returns></returns>
        public static int CalculatePricingAlgorithm(Dictionary<string, int> scenarioUser, List<SkuSetup> skuList, int price, Dictionary<string, int> dictValue)
        {
            foreach (string sc in scenarioUser.Keys)
            {
                int resetCounter = 0;
                int value = 0;
                bool modifiedFlag = true;
                
                foreach (string pc in dictValue.Keys)
                {
                    var promotion = dictValue.Where(p => p.Key.Contains(sc) && !p.Key.Contains("%"));
                    if (promotion.Count() > 0)
                    {
                        foreach (KeyValuePair<string, int> pro in promotion)
                        {
                            // Check for the special character that is provided for putting combination
                            if (!pro.Key.Contains("%"))
                            {
                                var item = Convert.ToInt32(pro.Key.Substring(0, pro.Key.Length - 1));
                                var itemChar = pro.Key.Substring(pro.Key.Length - 1);
                                var val = pro.Value;
                                int userItem = 0;

                                if (scenarioUser.TryGetValue(sc, out value))
                                {
                                    resetCounter = value;
                                }

                                if (scenarioUser.TryGetValue(sc, out value))
                                {
                                    userItem = value;
                                }

                                // Get the price list when resetCounter >0 
                                while (resetCounter > 0)
                                {
                                    if (item <= resetCounter)
                                    {
                                        price += val;
                                        resetCounter = resetCounter - item;
                                    }
                                    else
                                    {
                                        var sku = skuList.Where(p => p.SkuUnit == itemChar).Select(x => x.SkuUnitValue);
                                        price += resetCounter * (sku.FirstOrDefault());
                                        resetCounter = 0;
                                    }
                                }

                                //In case or reseCounter 0 remove the value from dictionary since it is already processed.
                                if (resetCounter == 0)
                                {
                                    dictValue.Remove(item + sc);
                                    scenarioUser.Remove(sc);
                                    modifiedFlag = false;
                                    break;
                                }
                            }
                            else
                            {
                                var combDisc = dictValue.Where(s => s.Key == sc).FirstOrDefault().Value;
                                price += combDisc;
                                modifiedFlag = false;
                            }
                        }
                    }
                    else
                    {                       

                        if (modifiedFlag)
                        {                            
                            if (!sc.Contains("%"))
                            {
                                var sku = skuList.Where(p => p.SkuUnit == sc).Select(x => x.SkuUnitValue);
                                price += sku.FirstOrDefault();
                            }
                            else
                            {
                                var combDisc = dictValue.Where(s => s.Key == sc).FirstOrDefault().Value;                                
                                
                                if (combDisc != 0)
                                {
                                    price += combDisc;
                                    break;
                                }
                                // In case value is not defined get the actual value.
                                else 
                                {
                                    price += dictValue.FirstOrDefault().Value;
                                    break;
                                }                                
                            }
                        }
                    }
                }
            }
            return price;
        }
    }
}

