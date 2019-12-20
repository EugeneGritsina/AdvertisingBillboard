using AdvertisingBillboard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertisingBillboard.Data.Memory
{
    public class VideosRepository : IVideosRepository
    {
        private ICollection<Video> _videos = new List<Video>();
        public Video[] Get()
        {
            return _videos.ToArray();
        }
        public Video Get(string name)
        {
            foreach (Video video in _videos)
            {
                if (video.name == name)
                    return video;
            }
            return null;
        }
        public void AddVideo(Video video)
        {
            _videos.Add(video);
        }

        public void DeleteVideo(Video video)
        {
            foreach (var videoFromRepository in _videos)
            {
                if (videoFromRepository.Equals(video))
                {
                    _videos.Remove(video);
                }
            }
        }

    }
}
