using UsageBillingApp.Services;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "usage-data.json";

        var loader = new InputLoader();
        var calculator = new InvoiceCalculator();
        var printer = new InvoicePrinter();

        var records = loader.LoadValidRecords(filePath);

        foreach (var record in records)
        {
            var result = calculator.Calculate(record);

            printer.Print(
                record,
                result.apiCost,
                result.storageCost,
                result.computeCost,
                result.total
            );
        }
    }
}