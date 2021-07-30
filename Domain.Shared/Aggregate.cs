using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Shared.DomainEvents;

namespace Domain.Shared
{
    public class Aggregate
    {
        private readonly List<INotification> _events = new List<INotification>();

        protected void Push(INotification domainEvent)
        {
            _events.Add(domainEvent);
        }

        public ReadOnlyCollection<INotification> GetDomainEvents()
        {
            return _events.AsReadOnly();
        }
    }
}