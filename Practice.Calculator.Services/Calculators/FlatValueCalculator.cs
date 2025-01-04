using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;

namespace Practice.Calculator.Services.Calculators
{
    internal sealed class FlatValueCalculator : ICalculator
    {
        public Task<decimal> CalculateAsync(decimal income)
        {
            try
            {
                // Constants
                const decimal flatValue = 10000m;
                const decimal threshold = 200000m;
                const decimal rate = 0.05m;

                // Validate if the input is valid
                if (income <= 0)
                    return Task.FromResult(0m);

                // Calculate tax based on the instructions in doc
                decimal tax = income < threshold ? Math.Round(income * rate, 2) : flatValue;

                return Task.FromResult(tax);
            }
            catch (Exception ex)
            {
                // Logging can be done here along with functionName and functionPath
                // Retaining the original stack trace of the exception for debugging
                throw; 
            }
        }

    }
}
