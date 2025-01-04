using Microsoft.AspNetCore.Mvc;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Shared.Models;

namespace Practice.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class CalculatorController : ControllerBase
    {
        private readonly ITaxCalculationService _taxCalculationService;

        public CalculatorController(ITaxCalculationService taxCalculationService)
        {
            _taxCalculationService = taxCalculationService;
        }

        [HttpPost("calculate-tax")]
        public async Task<ActionResult<CalculateResultDto>> Calculate(CalculateRequest request)
        {
            try
            {
                if(request != null && request.Income <= 0)
                {
                    return BadRequest("Income is Invalid");
                }

                // Delegate entire calculation process to service to avoid multiple responsibility 
                var result = await _taxCalculationService.CalculateTaxAsync(request.PostalCode, request.Income);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //Logging stackTrace in either DB or File
                return StatusCode(500, new { Error = "An unexpected error occurred." });
            }
        }
    }
}
