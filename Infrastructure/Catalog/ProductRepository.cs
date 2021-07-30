using System.Collections.Generic;
using System.Linq;
using Domain.Catalog;
using Domain.Shared;

namespace Infrastructure.Catalog
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
            return _products.Single(x => x.Sku == sku);
        }

        public void Save(Product product)
        {
            var index = _products.IndexOf(product);
            _products[index] = product; 
            
            _domainEventService.Publish(product.GetDomainEvents());
        }

        private readonly List<Product> _products = new()
        {
            new Product(new Sku("1"), new ProductName("Product 1"), new Visible(false), new Price(99, "USD")),
            new Product(new Sku("2"), new ProductName("Product 2"), new Visible(false), new Price(101, "EUR"))
        };

        
    }
}