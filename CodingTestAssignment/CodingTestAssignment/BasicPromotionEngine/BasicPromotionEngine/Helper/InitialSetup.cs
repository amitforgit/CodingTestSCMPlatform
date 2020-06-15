using System.Collections.Generic;

namespace BasicPromotionEngine.Helper
{
    /// <summary>
    /// InitialSetup
    /// </summary>
    public static class InitialSetup
    {
        /// <summary>
        /// InitializeSku
        /// </summary>
        /// <returns></returns>
        public static List<SkuSetup> InitializeSku()
        {
            // This should be updated with Initial Configuration values
            // Test Setup
            return new List<SkuSetup>
            {
                new SkuSetup("A", 50),
                new SkuSetup("B", 30),
                new SkuSetup("C", 20),
                new SkuSetup("D", 15)
            };
        }
    }
}
