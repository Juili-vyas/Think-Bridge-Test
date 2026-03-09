using System.Text.Json;
using UsageBillingApp.Models;

namespace UsageBillingApp.Services
{
    public class InputLoader
    {
        public List<UsageRecord> LoadValidRecords(string filePath)
        {
            var validRecords = new List<UsageRecord>();

            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<JsonElement>>(json);

            foreach (var item in data)
            {
                try
                {
                    if (!item.TryGetProperty("CustomerId", out var custId) ||
                        custId.ValueKind == JsonValueKind.Null)
                        throw new Exception();

                    if (!item.TryGetProperty("API_Calls", out var api) ||
                        api.ValueKind != JsonValueKind.Number)
                        throw new Exception();

                    if (!item.TryGetProperty("Storage_GB", out var storage) ||
                        storage.ValueKind != JsonValueKind.Number)
                        throw new Exception();

                    if (!item.TryGetProperty("Compute_Minutes", out var compute) ||
                        compute.ValueKind != JsonValueKind.Number)
                        throw new Exception();

                    var record = new UsageRecord
                    {
                        CustomerId = custId.GetString(),
                        API_Calls = api.GetInt32(),
                        Storage_GB = storage.GetDouble(),
                        Compute_Minutes = compute.GetInt32()
                    };

                    validRecords.Add(record);
                }
                catch
                {
                    Console.WriteLine("Skipped due to missing or invalid fields.");
                }
            }

            return validRecords;
        }
    }
}