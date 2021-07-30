namespace Domain.Warehouse
{
    public class InventoryLevel
    {
        private readonly int _inventory;

        public InventoryLevel(int inventory)
        {
            _inventory = inventory;
        }

        public int GetLevel()
        {
            return _inventory;
        }
    }
}