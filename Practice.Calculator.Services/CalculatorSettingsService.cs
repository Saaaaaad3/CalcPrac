using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Practice.Calculator.Data;
using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;

namespace Practice.Calculator.Services
{
    internal sealed class CalculatorSettingsService(CalculatorContext context, IMemoryCache memoryCache) : ICalculatorSettingsService
    {
        public Task<List<CalculatorSetting>> GetSettingsAsync(CalculatorType calculatorType)
        {
            return memoryCache.GetOrCreateAsync($"CalculatorSetting:{calculatorType}", entry =>
            {
                return context.Set<CalculatorSetting>().AsNoTracking().Where(_ => _.Calculator == calculatorType).ToListAsync();
            })!;
        }
    }
}