using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvertisingBillboard.Domain.Services
{
    public class UserService
    {
        private Device[] _devices;
        public Device[] GetDevices(User user)
        {
            return user.devices.ToArray();
        }

        public void DeleteDevices(Device[] userDevices, IDevicesRepository devicesRepository, int userDevicesLength)
        {
            Device[] devicesRepositoryArray = devicesRepository.Get();
            for(int i = 0; i < devicesRepositoryArray.Length; i++)
                for (int j = 0; j < userDevicesLength; j++)
                    if (devicesRepositoryArray[i] == userDevices[j])
                        devicesRepository.Delete(devicesRepositoryArray[i]);
        }
    }
}
