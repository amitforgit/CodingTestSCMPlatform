namespace BasicPromotionEngine
{
    /// <summary>
    /// SkuSetup
    /// </summary>
    public class SkuSetup
    {
        /// <summary>
        /// SkuUnit
        /// </summary>
        public string SkuUnit { get; set; }

        /// <summary>
        /// SkuUnitValue
        /// </summary>
        public int SkuUnitValue { get; set; }

        /// <summary>
        /// SkuSetup
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="unitValue"></param>
        public SkuSetup(string unit, int unitValue)
        {
            this.SkuUnit = unit;
            this.SkuUnitValue = unitValue;
        }
    }
}
