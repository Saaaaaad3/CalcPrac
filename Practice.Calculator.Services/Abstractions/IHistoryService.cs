using Practice.Calculator.Data.Models;

namespace Practice.Calculator.Services.Abstractions
{
    public interface IHistoryService
    {
        Task<List<CalculatorHistory>> GetHistoryAsync();

        Task AddAsync(CalculatorHistory calculatorHistory);
    }
}