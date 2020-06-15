using BusinessRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRulesEngine.BusinessRules
{
    public interface IAddFreeToPackingSlip
    {
        // Add Free Subscription
        void AddFreeSubscription(PaymentModel PaymentMethod);
    }
}
