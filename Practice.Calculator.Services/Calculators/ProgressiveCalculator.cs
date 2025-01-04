using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;

namespace Practice.Calculator.Services.Calculators
{
    internal sealed class ProgressiveCalculator : ICalculator
    {
        private readonly ICalculatorSettingsService _settingsService;

        public ProgressiveCalculator(ICalculatorSettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<decimal> CalculateAsync(decimal income)
        {
            try
            {
                if (income < 0) return 0;

                var taxBrackets = await _settingsService.GetSettingsAsync(CalculatorType.Progressive);
                decimal totalTax = 0;

                foreach (var bracket in taxBrackets.OrderBy(b => b.From))
                {
                    if (income > bracket.From)
                    {
                        var upperLimit = bracket.To is null ? income : Math.Min(income, bracket.To.Value);
                        var taxableIncome = upperLimit - bracket.From;

                        if (taxableIncome > 0)
                        {
                            var taxForThisBracket = Math.Round(taxableIncome * (bracket.Rate / 100), 2);
                            totalTax += taxForThisBracket;
                        }

                        // Break the loop early if no further iteration is needed. (To avoid getting worst Time complexity every single time)
                        if (bracket.To.HasValue && income <= bracket.To.Value)
                            break;
                    }
                }

                // final roundig to 2 decimal places
                totalTax = Math.Round(totalTax, 2);
                return totalTax;
            }
            catch (Exception)
            {
                // Logging can be done here along with functionName and functionPath
                throw; // Preserve original exception and stack trace
            }
        }
    }

}
