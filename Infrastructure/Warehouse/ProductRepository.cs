using System.Collections.Generic;
using System.Linq;
using Domain.Shared;
using Domain.Warehouse;

namespace Infrastructure.Warehouse
{
    public class ProductRepository : IProductRepository
    {
        private readonly DomainEventService _domainEventService;
        
        public ProductRepository(DomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }
        public Product Get(Sku sku)
        {
            return _products.Single(x => x.GetSku() == sku);
        }

        public void Save(Product product)
        {
            var index = _products.IndexOf(product);
            _products[index] = product; 
            
            _domainEventService.Publish(product.GetDomainEvents());
        }

        private readonly List<Product> _products = new()
        {
            new Product(new Sku("1")),
            new Product(new Sku("2"))
        };

        
    }
}