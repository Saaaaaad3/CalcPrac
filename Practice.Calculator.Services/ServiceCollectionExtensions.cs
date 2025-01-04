using Microsoft.Extensions.DependencyInjection;

using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Services.Calculators;

namespace Practice.Calculator.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCalculatorServices(this IServiceCollection services)
        {
            services.AddScoped<IPostalCodeService, PostalCodeService>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ICalculatorSettingsService, CalculatorSettingsService>();

            services.AddScoped<ICalculator, FlatRateCalculator>();
            services.AddScoped<ICalculator, FlatValueCalculator>();
            services.AddScoped<ICalculator, ProgressiveCalculator>();

            services.AddScoped<ITaxCalculationService, TaxCalculationService>();


            services.AddMemoryCache();
        }
    }
}