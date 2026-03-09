namespace UsageBillingApp.Models
{
    public class UsageRecord
    {
        public string CustomerId { get; set; }
        public int API_Calls { get; set; }
        public double Storage_GB { get; set; }
        public int Compute_Minutes { get; set; }
    }
}