using Domain.Shared;

namespace Domain.Warehouse
{
    public interface IProductRepository
    {
        Product Get(Sku sku);
        void Save(Product product);
    }
}