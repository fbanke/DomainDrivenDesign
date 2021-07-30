using System.Collections.Generic;
using Domain.Shared.DomainEvents;

namespace Infrastructure
{
    public class DomainEventService
    {
        private readonly List<IDomainEventHandler<IDomainEvent>> _handlers = new();

        public void Publish(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                foreach (var handler in _handlers)
                {
                    handler.Handle(domainEvent);
                }
            }
        }

        public void AddHandler(IDomainEventHandler<IDomainEvent> handler)
        {
            _handlers.Add(handler);
        }
    }
}