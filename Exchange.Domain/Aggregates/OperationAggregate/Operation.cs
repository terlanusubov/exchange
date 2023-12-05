
namespace Exchange.Domain.Aggregates.OperationAggregate
{
    public class Operation : AggregateRoot
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public string From { get; set; }
        public string To { get; private set; }
        public decimal ConvertedAmount { get; private set; }
        public DateTime Timestamp { get; private set; }


        public Operation(decimal amount, string from, string to, decimal convertedAmount)
        {
            Amount = amount;
            From = from;
            To = to;
            ConvertedAmount = convertedAmount;
        }


    }

}
