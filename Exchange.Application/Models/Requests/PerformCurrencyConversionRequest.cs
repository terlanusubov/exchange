namespace Exchange.Application.Models.Requests
{
    public class PerformCurrencyConversionRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}
