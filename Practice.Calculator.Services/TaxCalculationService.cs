using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Services.Exceptions;
using Practice.Calculator.Shared.Models;

namespace Practice.Calculator.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly IPostalCodeService _postalCodeService;
        private readonly IHistoryService _historyService;
        private readonly IEnumerable<ICalculator> _calculators;

        public TaxCalculationService(
            IPostalCodeService postalCodeService,
            IHistoryService historyService,
            IEnumerable<ICalculator> calculators)
        {
            _postalCodeService = postalCodeService;
            _historyService = historyService;
            _calculators = calculators;
        }

        public async Task<CalculateResultDto> CalculateTaxAsync(string postalCode, decimal income)
        {
            try
            {

                // Get the Calculator Type by postalCode
                var calculatorType = await _postalCodeService.CalculatorTypeAsync(postalCode);

                var calculator = _calculators.FirstOrDefault(calc => calc.GetType().Name.Contains(calculatorType.ToString()));

                if (calculator == null)
                    throw new CalculatorException("Unknown calculator type.");

                // calculator will decide which calculation function will be called
                decimal tax = await calculator.CalculateAsync(income);

                var historyEntry = new CalculatorHistory
                {
                    PostalCode = postalCode ?? "Unknown",
                    Income = income,
                    Tax = tax,
                    Timestamp = DateTime.UtcNow,
                    Calculator = calculatorType
                };

                // Add the calculation data in the table to maintain history.
                await _historyService.AddAsync(historyEntry);

                return new CalculateResultDto
                {
                    Calculator = calculatorType.Value.ToString(),
                    Income = income,
                    Tax = tax
                };
            }
            catch (Exception ex)
            {
                // Would have logged in either DB or a File.
                // Along with functionName and functionPath.
                throw;
            }
        }
    }

}
