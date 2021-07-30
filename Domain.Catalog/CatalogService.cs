using Domain.Shared;

namespace Domain.Catalog
{
    public class CatalogService
    {
        private readonly IProductRepository _productRepository;

        public CatalogService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(Sku sku)
        {
            return _productRepository.Get(sku);
        }
    }
}