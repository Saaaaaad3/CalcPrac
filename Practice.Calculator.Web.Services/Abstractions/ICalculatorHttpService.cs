using Practice.Calculator.Web.Services.Models;

namespace Practice.Calculator.Web.Services.Abstractions
{
    public interface ICalculatorHttpService
    {
        Task<List<PostalCode>> GetPostalCodesAsync();

        Task<List<CalculatorHistory>> GetHistoryAsync();

        Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest);
    }
}