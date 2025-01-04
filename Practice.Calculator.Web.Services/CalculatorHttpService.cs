using System.Net.Http;
using System.Net.Http.Json;
using Practice.Calculator.Web.Services.Abstractions;
using Practice.Calculator.Web.Services.Models;

namespace Practice.Calculator.Web.Services
{
    public class CalculatorHttpService : ICalculatorHttpService
    {
        private readonly HttpClient httpClient;

        public CalculatorHttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PostalCode>> GetPostalCodesAsync()
        {
            var response = await httpClient.GetAsync("api/User/GetAllPostalcodes"); 
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch postal codes, status code: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<List<PostalCode>>() ?? new List<PostalCode>();
        }

        public async Task<List<CalculatorHistory>> GetHistoryAsync()
        {
            try
            {

                var response = await httpClient.GetAsync("api/History/history");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Cannot fetch history, status code: {response.StatusCode}");
                }

                return await response.Content.ReadFromJsonAsync<List<CalculatorHistory>>() ?? new List<CalculatorHistory>();
            }
            catch (Exception ex) 
            {
                //Logging to be done in a file or with centralised logging call to a DB
                throw;
            }
        }

        public async Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Calculator/calculate-tax", calculationRequest);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Cannot calculate tax, status code: {response.StatusCode}");
                }
                return await response.Content.ReadFromJsonAsync<CalculateResult>() ?? throw new Exception("Invalid response content");
            }
            catch(Exception ex)
            {
                //Logging to be done in a file or with centralised logging call to a DB
                throw;
            }
        }
    }
}
