namespace Practice.Calculator.Shared.Models
{
    public sealed class CalculateResultDto
    {
        public string Calculator { get; set; }
        public decimal Income { get; set; }

        public decimal Tax { get; set; }
    }
}