using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisingBillboard.Domain
{
    public interface IDevicesRepository
    {
        Device[] Get();
        Device Get(string deviceName);
        void Create(Device device);
        void Delete(Device device);
    }
}
