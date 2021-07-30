namespace Domain.Shared
{
    public class Price
    {
        private decimal _price;
        private string _currency;

        public Price(decimal price, string currency)
        {
            _price = price;
            _currency = currency;
        }

        public string GetFormattedPrice()
        {
            return $"{_price} {_currency}";
        }
    }
}