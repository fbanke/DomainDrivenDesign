using System.Collections.Generic;
using Domain.Shared.DomainEvents;

namespace Infrastructure
{
    public class DomainEventService
    {
        private readonly List<INotificationHandler<INotification>> _handlers = new();

        public void Publish(IEnumerable<INotification> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                foreach (var handler in _handlers)
                {
                    handler.Handle(domainEvent);
                }
            }
        }

        public void AddHandler(INotificationHandler<INotification> handler)
        {
            _handlers.Add(handler);
        }
    }
}