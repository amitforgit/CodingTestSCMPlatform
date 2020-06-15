using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicPromotionEngineUnitTests
{
    [TestClass]
    public class BasicPromotionEngineUnitTest
    {        
        [TestMethod]
        public void TestScenarioA()
        {            
            // Arrange
            Dictionary<string, int> scenarioUser = new Dictionary<string, int>();
            scenarioUser.Add("A", 1);
            scenarioUser.Add("B", 1);
            scenarioUser.Add("C", 1);
            
            // Act
            double totalPrice = CalculatePromotion(skuUnit, listSku);

            // Assert
            //double actual = account.Balance;
            //Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
