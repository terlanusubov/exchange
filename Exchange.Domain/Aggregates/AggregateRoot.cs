namespace Exchange.Domain.Aggregates
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
