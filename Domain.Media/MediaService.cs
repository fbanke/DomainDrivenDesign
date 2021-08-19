using Domain.Shared;

namespace Domain.Media
{

    public class MediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
        public Media Get(MediaId mediaId)
        {
            return _mediaRepository.Get(mediaId);
        }

        public void Update(Media media)
        {
            _mediaRepository.Update(media);
        }
    }

    public interface IMediaRepository
    {
        Media Get(MediaId mediaId);
        void Update(Media media);
    }
}