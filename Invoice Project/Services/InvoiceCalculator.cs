using UsageBillingApp.Constants;
using UsageBillingApp.Models;

namespace UsageBillingApp.Services
{
    public class InvoiceCalculator
    {
        public (decimal apiCost, decimal storageCost, decimal computeCost, decimal total)
        Calculate(UsageRecord record)
        {
            decimal apiCost;

            if (record.API_Calls <= PricingConstants.ApiLimit)
            {
                apiCost = record.API_Calls * PricingConstants.ApiPrice1;
            }
            else
            {
                int tier1 = PricingConstants.ApiLimit;
                int tier2 = record.API_Calls - tier1;

                apiCost = (tier1 * PricingConstants.ApiPrice1) + (tier2 * PricingConstants.ApiPrice2);
            }

            decimal storageCost =
                (decimal)record.Storage_GB * PricingConstants.StoragePricePerGB;

            decimal computeCost =
                record.Compute_Minutes * PricingConstants.ComputePricePerMinute;

            decimal total = apiCost + storageCost + computeCost;

            return (apiCost, storageCost, computeCost, total);
        }
    }
}