using Domain.Shared.DomainEvents;

namespace Domain.Catalog
{
    public class InventoryLevelChangedEventHandler : IDomainEventHandler<InventoryLevelChangedEvent>, IDomainEventHandler<IDomainEvent>
    {
        private readonly IProductRepository _productRepository;

        public InventoryLevelChangedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Handle(InventoryLevelChangedEvent notification)
        {
            var product = _productRepository.Get(notification.GetSku());

            product.InventoryChanged(notification.GetInventoryLevel());

            _productRepository.Save(product);
        }

        public void Handle(IDomainEvent domainEvent)
        {
            if (domainEvent is InventoryLevelChangedEvent @event)
            {
                Handle(@event);
            }
        }
    }
}
