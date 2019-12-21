using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisingBillboard.Domain.Services
{
    public class VideoService
    {
        /*
        public Video[] GetVideos(Device device)
        {
            return devices.videos.ToArray();
        }
        */
        public void DeleteVideo(Video video, IVideosRepository _videos)
        {

            Video[] videosRepositoryArray = _videos.Get();
            for (int i = 0; i < videosRepositoryArray.Length; i++)
                if (videosRepositoryArray[i] == video)
                {
                    _videos.DeleteVideo(videosRepositoryArray[i]);
                    return;
                }

        }
    }
}
