using BusinessRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRulesEngine.BusinessRules
{
    public class PaymentSystemForPhysicalProduct : IPaymentSystem
    {
        public PaymentSystemForPhysicalProduct()
        {
        }
       
        // Implement the Package Slip Generation for Physical Product
        public int GenerateSlipForShipping(PaymentModel PaymentMethod)
        {
            // To implement the logic
            throw new NotImplementedException();
        }
    }
}
