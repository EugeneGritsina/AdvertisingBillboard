using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdvertisingBillboard.Domain;

namespace AdvertisingBillboard.Data.Memory
{
    public class DevicesRepository : IDevicesRepository
    {
        private ICollection<Device> _devices = new List<Device>();

        public Device[] Get()
        {
            return _devices.ToArray();
        }
        public Device Get(string deviceName)
        {
            foreach (Device device in _devices)
            {
                if (device.deviceName == deviceName)
                    return device;
            }
            return null;
        }

        public void Create(Device device)
        {
            _devices.Add(device);
        }

        public void Delete(Device device)
        {
            foreach (var _device in _devices)
            {
                if (_device.Equals(device))
                {
                    _devices.Remove(device);
                    return;
                }
            }
        }


    }
}
