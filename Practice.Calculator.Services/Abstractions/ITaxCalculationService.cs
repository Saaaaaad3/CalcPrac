using Practice.Calculator.Data.Models;
using Practice.Calculator.Shared.Models;

namespace Practice.Calculator.Services.Abstractions
{
    public  interface ITaxCalculationService
    {
        Task<CalculateResultDto> CalculateTaxAsync(string postalCode, decimal income);
    }
}
