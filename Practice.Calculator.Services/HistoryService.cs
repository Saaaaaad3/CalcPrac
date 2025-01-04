using Microsoft.EntityFrameworkCore;

using Practice.Calculator.Data;
using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;

namespace Practice.Calculator.Services
{
    internal sealed class HistoryService(CalculatorContext context) : IHistoryService
    {
        public async Task AddAsync(CalculatorHistory history)
        {
            history.Timestamp = DateTime.Now;

            await context.AddAsync(history);
            await context.SaveChangesAsync();
        }

        public Task<List<CalculatorHistory>> GetHistoryAsync()
        {
            return context.Set<CalculatorHistory>()
                .OrderByDescending(_ => _.Timestamp)
                .ToListAsync();
        }
    }
}