using System.Collections.Generic;
using Domain.Shared;

namespace Domain.Catalog
{
    public interface IProductRepository
    {
        Product Get(Sku sku);
        void Save(Product product);
        IEnumerable<Product> GetByMediaId(MediaId getMediaId);
    }
}