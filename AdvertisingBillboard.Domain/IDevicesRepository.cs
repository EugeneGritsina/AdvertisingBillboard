using System;

namespace AdvertisingBillboard.Domain
{
    public interface IDevicesRepository
    {
        Device[] Get();
        Device[] Get(Guid userId);
        Device Get(string deviceName);
        void Create(Device device);
        void Delete(Guid userId);
        void Delete(string name);
    }
}
