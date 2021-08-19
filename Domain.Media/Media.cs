using System;
using Domain.Shared;
using Domain.Shared.DomainEvents;

namespace Domain.Media
{
    public class Media : Aggregate
    {
        public Uri MediaLink { get; set;  }
        public MediaType MediaType {get;set; }
        //public Sku ProductIdentifier { get; set; }
        public MediaId MediaId { get; set; }

        public void UpdateMediaLink(Uri newUri)
        {
            MediaLink = newUri;
            Push(new MediaUriChangedEvent(MediaId, MediaLink.ToString()));
        }
    }

    public enum MediaType
    {
        IMAGE,
        VIDEO
    }
}