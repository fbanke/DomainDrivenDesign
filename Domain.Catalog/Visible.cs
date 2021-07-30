namespace Domain.Catalog
{
    public class Visible
    {
        private bool _inStock;

        public Visible(bool inStock)
        {
            _inStock = inStock;
        }

        public bool IsInStock()
        {
            return _inStock;
        }
        public void InStock()
        {
            _inStock = true;
        }

        public void NotInStock()
        {
            _inStock = false;
        }
    }
}