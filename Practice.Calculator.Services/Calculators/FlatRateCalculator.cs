using Practice.Calculator.Services.Abstractions;

namespace Practice.Calculator.Services.Calculators
{
    internal sealed class FlatRateCalculator : ICalculator
    {
        public Task<decimal> CalculateAsync(decimal income)
        {
            try
            {
                const decimal taxRate = 0.175m; // decimal for 17.5%

                // Validate the income (no tax for zero or negative income)
                if (income <= 0)
                    return Task.FromResult(0m);

                // Calculation based on instructions given in doc
                decimal tax = Math.Round(income * taxRate, 2, MidpointRounding.AwayFromZero);

                return Task.FromResult(tax);
            }
            catch (Exception ex)
            {
                // Logging can be done here along with functionName and functionPath
                throw; // Preserve the original exception and stack trace
            }
        }

    }
}
