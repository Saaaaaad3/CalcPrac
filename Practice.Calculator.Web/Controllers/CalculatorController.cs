using Microsoft.AspNetCore.Mvc;
using Practice.Calculator.Web.Models;
using Practice.Calculator.Web.Services.Abstractions;
using Practice.Calculator.Web.Services.Models;

namespace Practice.Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorHttpService calculatorHttpService;

        public CalculatorController(ICalculatorHttpService calculatorHttpService)
        {
            this.calculatorHttpService = calculatorHttpService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CalculateRequestViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculateRequestViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", request);
            }

            try
            {
                var calculateRequest = new CalculateRequest
                {
                    PostalCode = request.PostalCode,
                    Income = request.Income
                };

                var result = await calculatorHttpService.CalculateTaxAsync(calculateRequest);
                ViewData["TaxResult"] = $"Tax: { result.Tax}";
                ViewData["CalculatorType"] = result.Calculator;
            }
            catch (Exception ex)
            {
                ViewData["TaxResult"] = $"Error: {ex.Message}";
                ViewData["CalculatorType"] = "Unknown";
            }

            return View("Index", request);
        }

        public async Task<IActionResult> History(int page = 1, int pageSize = 10)
        {
            var allHistory = await calculatorHttpService.GetHistoryAsync();

            int totalRecords = allHistory.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);


            //Quantified result should be taken from database, basis on the number sent in the request from here to avoid bulky data.
            //Have not applied yet due to time constraint.
            var historyForPage = allHistory.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new CalculatorHistoryPagination
            {
                CalculatorHistory = historyForPage,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        // if we want to input postalCodes with Select view

        //public async Task<IActionResult> AllPostalCodes()
        //{
        //    var postalCodes = await calculatorHttpService.GetPostalCodesAsync();
        //    return View(postalCodes);
        //}


    }
}
