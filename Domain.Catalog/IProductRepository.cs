using Domain.Shared;

namespace Domain.Catalog
{
    public interface IProductRepository
    {
        Product Get(Sku sku);
        void Save(Product product);
    }
}