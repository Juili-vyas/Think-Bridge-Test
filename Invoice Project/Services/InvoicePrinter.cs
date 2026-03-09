using UsageBillingApp.Models;

namespace UsageBillingApp.Services
{
    public class InvoicePrinter
    {
        public void Print(
            UsageRecord record,
            decimal apiCost,
            decimal storageCost,
            decimal computeCost,
            decimal total)
        {
            Console.WriteLine($"Invoice for Customer: {record.CustomerId}");
            Console.WriteLine($"API Calls: {record.API_Calls} calls -> ${apiCost:F2}");
            Console.WriteLine($"Storage: {record.Storage_GB} GB -> ${storageCost:F2}");
            Console.WriteLine($"Compute Time: {record.Compute_Minutes} minutes -> ${computeCost:F2}");
            Console.WriteLine($"Total: ${total:F2}");
            Console.WriteLine();
        }
    }
}