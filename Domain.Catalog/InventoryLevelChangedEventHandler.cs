using Domain.Shared.DomainEvents;

namespace Domain.Catalog
{
    public class InventoryLevelChangedEventHandler : INotificationHandler<InventoryLevelChangedEvent>, INotificationHandler<INotification>
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

        public void Handle(INotification notification)
        {
            if (notification is InventoryLevelChangedEvent @event)
            {
                Handle(@event);
            }
        }
    }
}
