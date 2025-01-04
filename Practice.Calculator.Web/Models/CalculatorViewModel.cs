using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practice.Calculator.Web.Models
{
    public sealed class CalculatorViewModel
    {
        public SelectList PostalCodes { get; set; }

        public string PostalCode { get; set; }

        public decimal Income { get; set; }
    }
}