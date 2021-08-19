using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Domain.Shared
{
    public class MediaId: ValueObject
    {
        private readonly string _mediaId;

        public MediaId(string mediaId)
        {
            _mediaId = mediaId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _mediaId;
        }
    }
}