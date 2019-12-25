using System;
using System.Collections.Generic;
using System.Linq;
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

        public Device[] Get(Guid userId)
        {
            var devices = new List<Device>();
            foreach (var device in _devices)
            {
                if (device.User.Id == userId)
                    devices.Add(device);
            }

            return devices.ToArray();
        }

        public Device Get(string deviceName)
        {
            foreach (Device device in _devices)
            {
                if (device.Name == deviceName)
                    return device;
            }
            return null;
        }

        public void Create(Device device)
        {
            _devices.Add(device);
        }

        public void Delete(Guid userId)
        {
            var devices = new List<Device>();
            foreach (var device in _devices)
            {
                if (device.User.Id != userId)
                {
                   devices.Add(device);
                }
            }

            _devices = devices;
        }

        public void Delete(string name)
        {
            foreach (var device in _devices)
            {
                if (device.Name == name)
                {
                    _devices.Remove(device);
                    return;
                }
            }
        }
    }
}
