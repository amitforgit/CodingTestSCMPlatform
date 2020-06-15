using BasicPromotionEngine;
using BasicPromotionEngine.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BasicPromotionEngineUnitTestProject
{
    [TestClass]
    public class BasicPromotionEngineUnitTestProject
    {
        [TestMethod]
        public void TestScenarioA()
        {
            // Initial Sku defined
            var listSku = InitialSetup.InitializeSku();
            Dictionary<string, int> skuUnit = new Dictionary<string, int>();

            // Input Scenario
            var scenario = "1A,1B,1C";
            AddScenarioToDictionary(skuUnit, scenario);

            Dictionary<string, int> dictConfigValue = new Dictionary<string, int>();
            dictConfigValue.Add("3A", 130);
            dictConfigValue.Add("2B", 45);
            dictConfigValue.Add("1C%1D", 30);

            // Act
            double totalPrice = Program.CalculatePricingAlgorithm(skuUnit, listSku, 0, dictConfigValue);

            // Assert            
            Assert.AreEqual(100, totalPrice);

        }

        private static void AddScenarioToDictionary(Dictionary<string, int> skuUnit, string scenario)
        {
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
        }

        [TestMethod]
        public void TestScenarioB()
        {
            // Initial Sku defined
            var listSku = InitialSetup.InitializeSku();
            Dictionary<string, int> skuUnit = new Dictionary<string, int>();

            // Input Scenario
            var scenario = "5A,5B,1C";
            AddScenarioToDictionary(skuUnit, scenario);

            Dictionary<string, int> dictConfigValue = new Dictionary<string, int>();
            dictConfigValue.Add("3A", 130);
            dictConfigValue.Add("2B", 45);
            dictConfigValue.Add("1C%1D", 30);

            // Act
            double totalPrice = Program.CalculatePricingAlgorithm(skuUnit, listSku, 0, dictConfigValue);

            // Assert            
            Assert.AreEqual(370, totalPrice);

        }

        [TestMethod]
        public void TestScenarioC()
        {
            // Initial Sku defined
            var listSku = InitialSetup.InitializeSku();
            Dictionary<string, int> skuUnit = new Dictionary<string, int>();

            // Input Scenario
            var scenario = "3A,5B,1C%1D";
            AddScenarioToDictionary(skuUnit, scenario);

            Dictionary<string, int> dictConfigValue = new Dictionary<string, int>();
            dictConfigValue.Add("3A", 130);
            dictConfigValue.Add("2B", 45);
            dictConfigValue.Add("1C%1D", 30);

            // Act
            double totalPrice = Program.CalculatePricingAlgorithm(skuUnit, listSku, 0, dictConfigValue);

            // Assert            
            Assert.AreEqual(280, totalPrice);
        }
    }
}
