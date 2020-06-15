using BusinessRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRulesEngine.BusinessRules
{
    public interface ICommissionPayment
    {
        // Generate Commission Payment
        void GenerateCommissionPayment(PaymentModel PaymentMethod);
    }
}
