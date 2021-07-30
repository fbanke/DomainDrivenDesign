using Domain.Shared;

namespace Domain.Catalog
{
    public class ProductName : TranslatedString
    {
        public ProductName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}