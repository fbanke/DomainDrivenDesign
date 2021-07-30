namespace Domain.Shared.DomainEvents
{
    public interface IDomainEventHandler<in TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent notification);
    }
}