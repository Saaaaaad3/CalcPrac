namespace Practice.Calculator.Web.Models
{
    public class CalculatorHistoryPagination : CalculatorHistoryViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
