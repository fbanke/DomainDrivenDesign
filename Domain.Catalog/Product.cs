using System;
using Domain.Shared;

namespace Domain.Catalog
{
    public class Product : Aggregate
    {
        public Sku Sku { get; }
        public ProductName ProductName { get; }
        public Price Price { get; }
        public Visible Visible { get; }

        public MediaId Media { get; }
        public Uri MediaLink { get; private set; }

        public Product(Sku sku, ProductName productName, Visible visible, Price price)
        {
            Sku = sku;
            ProductName = productName;
            Visible = visible;
            Price = price;
        }

        public void InventoryChanged(int inventoryLevel)
        {
            if (inventoryLevel <= 0)
            {
                Visible.NotInStock();
            }
            else
            {
                Visible.InStock();
            }
        }

        public void MediaUriChanged(string uri)
        {
            MediaLink = new Uri(uri);
        }
    }
}