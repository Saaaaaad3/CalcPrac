using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Practice.Calculator.Data;
using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Services.Exceptions;

namespace Practice.Calculator.Services
{
    internal sealed class PostalCodeService(CalculatorContext context, IMemoryCache memoryCache) : IPostalCodeService
    {
        // Get the Postal Codes from DB if not present already in the cache
        public Task<List<PostalCode>> GetPostalCodesAsync()
        {
            return memoryCache.GetOrCreateAsync("PostalCodes", _ => context.Set<PostalCode>().AsNoTracking().ToListAsync())!;
        }

        public async Task<CalculatorType?> CalculatorTypeAsync(string code)
        {
            try
            {

                var postalCodes = await this.GetPostalCodesAsync();

                var postalCode = postalCodes.FirstOrDefault(pc => pc.Code == code);

                // If postal code is not found
                if (postalCode == null)
                {
                    throw new CalculatorException($"Postal code '{code}' not found.");
                }

                // If no type of calculator returned for the given postal code
                if (!postalCode.Calculator.HasValue)
                {
                    throw new CalculatorException($"No calculator type found for postal code '{code}'.");
                }

                return postalCode.Calculator;
            }
            catch (Exception ex)
            {
                // Logging with functionNamr and functionPath
                throw;
            }
        }
    }
}
