using AdvertisingBillboard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertisingBillboard.Data.Memory
{
    public class VideosRepository : IVideosRepository
    {
        private readonly ICollection<Video> _videos = new List<Video>();
        
        public Video[] Get()
        {
            return _videos.ToArray();
        }
        
        public Video Get(string name)
        {
            foreach (Video video in _videos)
            {
                if (video.Name == name)
                    return video;
            }
            return null;
        }
        
        public void Create(Video video)
        {
            _videos.Add(video);
        }

        public void Delete(Video video)
        {
            foreach (var videoFromRepository in _videos)
            {
                if (videoFromRepository.Equals(video))
                {
                    _videos.Remove(video);
                    return;
                }
            }
        }

    }
}
