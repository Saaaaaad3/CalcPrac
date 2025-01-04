namespace Practice.Calculator.Web.Services.Models
{
    public sealed class CalculatorHistory
    {
        public long id { get;set; }
        public string PostalCode { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Income { get; set; }

        public decimal Tax { get; set; }

        public int Calculator { get; set; }
    }
}