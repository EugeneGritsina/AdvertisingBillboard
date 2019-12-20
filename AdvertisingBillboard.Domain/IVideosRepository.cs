using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisingBillboard.Domain
{
    public interface IVideosRepository
    {
        Video[] Get();
        Video Get(string name);
        void AddVideo(Video video);
        void DeleteVideo(Video video);
    }
}
