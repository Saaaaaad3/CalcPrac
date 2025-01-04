using Microsoft.AspNetCore.Mvc;
using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Shared.Models;

namespace Practice.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IPostalCodeService _postalCodeService;
        ILogger<CalculatorController> _logger;
        public UserController(IPostalCodeService postalCodeService, ILogger<CalculatorController> logger)
        {
            _postalCodeService = postalCodeService;
            _logger = logger;
        }

        [HttpGet("GetAllPostalCodes")]
        public async Task<ActionResult<List<PostalCodeInfo>>> GetAllPostalCodes()
        {
            try
            {
                // Fetch postal codes from the service
                var postalCodes = await _postalCodeService.GetPostalCodesAsync();

                // Map the postal codes to include the proper string for the 'calculator' field
                var mappedPostalCodes = postalCodes.Select(pc => new PostalCodeInfo
                {
                    code = pc.Code,
                    calculator = pc.Calculator switch
                    {
                        CalculatorType.Progressive => "Progressive",
                        CalculatorType.FlatValue => "Flat Value",
                        CalculatorType.FlatRate => "Flat Rate",  
                        _ => "Unknown"       
                    }
                }).ToList();

                return Ok(mappedPostalCodes);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch postal codes.");
                return StatusCode(500, new { Error = "Failed to fetch postal codes." });
            }
        }

    }
}
