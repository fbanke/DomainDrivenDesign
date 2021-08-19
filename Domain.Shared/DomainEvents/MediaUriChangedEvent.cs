namespace Domain.Shared.DomainEvents
{
    public class MediaUriChangedEvent : IDomainEvent
    {
        private readonly MediaId _mediaId;
        private readonly string _uri;

        public MediaUriChangedEvent(MediaId mediaId, string uri)
        {
            _mediaId = mediaId;
            _uri = uri;
        }

        public string GetUri()
        {
            return _uri;
        }

        public MediaId GetMediaId()
        {
            return _mediaId;
        }
    }
}