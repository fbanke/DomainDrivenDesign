using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Media;

namespace Infrastructure.Media 
{
    public class MediaRepository : IMediaRepository
    {
        private List<Domain.Media.Media> _medias = new List<Domain.Media.Media>
        {
            new Domain.Media.Media
            {
                MediaId = new MediaId("1"),
                MediaLink = new Uri("https://via.placeholder.com/150"),
                MediaType = MediaType.IMAGE
            },
            new Domain.Media.Media
            {
                MediaId = new MediaId("2"),
                MediaLink = new Uri("https://via.placeholder.com/250"),
                MediaType = MediaType.IMAGE
            }
        };

        private readonly DomainEventService _domainEventService;

        public MediaRepository(DomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }
        public Domain.Media.Media Get(MediaId mediaId)
        {
            return _medias.Single(x => x.MediaId == mediaId);
        }

        public void Update(Domain.Media.Media media)
        {
            var index = _medias.IndexOf(media);
            _medias[index] = media;
            
            _domainEventService.Publish(media.GetDomainEvents());
        }
    }
}