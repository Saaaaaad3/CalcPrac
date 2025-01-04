using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Practice.Calculator.Web.Services.Abstractions;
using Practice.Calculator.Web.Services.Models;

namespace Practice.Calculator.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCalculatorHttpServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorHttpService, CalculatorHttpService>();

            // For applying the base URL automatically for any API calls.
            // Only needed to change at one place(appsetting) when deploying on production environment.
            services.AddHttpClient<ICalculatorHttpService, CalculatorHttpService>((serviceProvider, client) =>
            {
                var apiSettings = serviceProvider.GetRequiredService<IOptions<AppSettingsConfig>>().Value;
                client.BaseAddress = new Uri(apiSettings.ApiUrl);
            });


        }
    }
}