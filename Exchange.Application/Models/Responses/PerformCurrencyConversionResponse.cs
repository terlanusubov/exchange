namespace Exchange.Application.Models.Responses
{
    public class PerformCurrencyConversionResponse
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
