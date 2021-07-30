using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Domain.Shared
{
    public class Sku : ValueObject
    {
        private readonly string _sku;

        public Sku(string sku)
        {
            _sku = sku;
        }

        public string GetSku()
        {
            return _sku;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _sku;
        }
    }
}