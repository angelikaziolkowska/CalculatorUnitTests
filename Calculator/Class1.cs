using System;


namespace Calculator.Services
{
    public class MyCalculator
    {
        const double INSURANCE_PREMIUM_TAX = 12;
        const string INVALID_NET_PREMIUM_SUPPLIED = "Invalid NET Premium Supplied";
        const string INVALID_COMMISSION_PERCENTAGE_SUPPLIED = "Invalid Comission Percentage Supplied";
        const string INVALID_DISCOUNT_PERCENTAGE_SUPPLIED = "Invalid Discount Percentage Supplied";

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
      
        public double CalculateInsurancePrice(double netPremium, double comissionPercentage, double discountPercentage)
        {
            if (netPremium <= 0)
                throw new ArgumentOutOfRangeException(INVALID_NET_PREMIUM_SUPPLIED, nameof(netPremium));

            if (comissionPercentage <= 0)
                throw new ArgumentOutOfRangeException(INVALID_COMMISSION_PERCENTAGE_SUPPLIED, nameof(comissionPercentage));

            if (discountPercentage >= 0 || discountPercentage <= -100)
                throw new ArgumentOutOfRangeException(INVALID_DISCOUNT_PERCENTAGE_SUPPLIED, nameof(discountPercentage));

            var finalInsurancePrice = AddPercentage(netPremium,  comissionPercentage);
            finalInsurancePrice = AddPercentage(finalInsurancePrice, discountPercentage);
            finalInsurancePrice = AddPercentage(finalInsurancePrice, INSURANCE_PREMIUM_TAX);
            return Math.Round(finalInsurancePrice,2);
        }

        private double AddPercentage(double startPrice, double percentage)
        {
            return (percentage/100*startPrice)+startPrice;
        }
    }
}
