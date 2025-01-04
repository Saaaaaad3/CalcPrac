using Microsoft.AspNetCore.Mvc;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Shared.Models;

namespace Practice.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;
        ILogger<CalculatorController> _logger;
        public HistoryController(IHistoryService historyService, ILogger<CalculatorController> logger)
        {
            _historyService = historyService;
            _logger = logger;
        }

        [HttpGet("history")]
        public async Task<ActionResult<List<CalculatorHistoryDto>>> GetHistory()
        {
            try
            {
                var history = await _historyService.GetHistoryAsync();
                return Ok(history);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch history.");
                return StatusCode(500, new { Error = "Failed to fetch history." });
            }
        }
    }
}
