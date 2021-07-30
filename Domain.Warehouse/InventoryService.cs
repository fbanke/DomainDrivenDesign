using Domain.Shared;

namespace Domain.Warehouse
{
    public class InventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(Sku sku)
        {
            return _productRepository.Get(sku);
        }

        public void SetInventory(Sku sku, InventoryLevel inventoryLevel)
        {
            var product = _productRepository.Get(sku);
            product.Set(inventoryLevel);

            _productRepository.Save(product);
        }
    }
}