namespace Domain.Shared.DomainEvents
{
    public class InventoryLevelChangedEvent : IDomainEvent
    {
        private readonly Sku _sku;
        private readonly int _inventoryLevel;

        public InventoryLevelChangedEvent(Sku sku, int inventoryLevel)
        {
            _sku = sku;
            _inventoryLevel = inventoryLevel;
        }

        public Sku GetSku()
        {
            return _sku;
        }

        public int GetInventoryLevel()
        {
            return _inventoryLevel;
        }
    }
}