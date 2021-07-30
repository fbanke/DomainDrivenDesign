using Domain.Shared;
using Domain.Shared.DomainEvents;

namespace Domain.Warehouse
{
    public class Product : Aggregate
    {
        private readonly Sku _sku;
        public Inventory Inventory { get;  } = new();

        public Product(Sku sku)
        {
            _sku = sku;
        }

        public Sku GetSku()
        {
            return _sku;
        }

        public void Set(InventoryLevel inventoryLevel)
        {
            Inventory.SetLevel(inventoryLevel);

            Push(new InventoryLevelChangedEvent(_sku, inventoryLevel.GetLevel()));
        }
    }
}
