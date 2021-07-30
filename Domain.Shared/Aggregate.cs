using System.Collections.Generic;
using Domain.Shared.DomainEvents;

namespace Domain.Shared
{
    public class Aggregate
    {
        private readonly List<IDomainEvent> _events = new();

        protected void Push(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            return _events.AsReadOnly();
        }
    }
}