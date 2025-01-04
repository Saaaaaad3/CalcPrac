using Practice.Calculator.Data.Models;

namespace Practice.Calculator.Services.Abstractions
{
    public interface IPostalCodeService
    {
        Task<List<PostalCode>> GetPostalCodesAsync();

        Task<CalculatorType?> CalculatorTypeAsync(string code);
    }
}