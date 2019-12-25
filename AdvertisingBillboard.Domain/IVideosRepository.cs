namespace AdvertisingBillboard.Domain
{
    public interface IVideosRepository
    {
        Video[] Get();
        Video Get(string name);
        void Create(Video video);
        void Delete(Video video);
    }
}
