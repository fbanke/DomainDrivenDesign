namespace Domain.Warehouse
{
    public class Inventory
    {
        private InventoryLevel _inventoryLevel;
        public void SetLevel(InventoryLevel inventoryLevel)
        {
            _inventoryLevel = inventoryLevel;
        }

        public int GetInventoryLevel()
        {
            return _inventoryLevel.GetLevel();
        }
    }
}