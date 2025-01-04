using Practice.Calculator.Data.Models;

namespace Practice.Calculator.Services.Models
{
    public sealed class CalculateResult
    {
        public CalculatorType Calculator { get; set; }

        public decimal Tax { get; set; }
    }
}