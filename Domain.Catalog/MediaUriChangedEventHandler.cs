using Domain.Shared.DomainEvents;

namespace Domain.Catalog
{
    public class MediaUriChangedEventHandler : IDomainEventHandler<MediaUriChangedEvent>, IDomainEventHandler<
    IDomainEvent>
    {
    private readonly IProductRepository _productRepository;

    public MediaUriChangedEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Handle(MediaUriChangedEvent notification)
    {
        var products = _productRepository.GetByMediaId(notification.GetMediaId());

        foreach(var product in products)
        {
            product.MediaUriChanged(notification.GetUri());
            _productRepository.Save(product);
        }
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
