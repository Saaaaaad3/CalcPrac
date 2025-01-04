using Practice.Calculator.Data.Models;

namespace Practice.Calculator.Services.Abstractions
{
    public interface ICalculatorSettingsService
    {
        Task<List<CalculatorSetting>> GetSettingsAsync(CalculatorType calculatorType);
    }
}