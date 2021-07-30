using Domain.Shared;

namespace Domain.Catalog
{
    public interface IProductRepository
    {
        Product Get(Sku getSku);
        void Save(Product product);
    }
}