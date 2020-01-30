using AdvertisingBillboard.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDevicesRepository _devicesRepository;
        private readonly IUsersRepository _usersRepository;

        public DeviceController(IDevicesRepository devicesRepository, IUsersRepository usersRepository)
        {
            _devicesRepository = devicesRepository;
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public RedirectResult Delete(string name)
        {
            _devicesRepository.Delete(name);
            return Redirect("~/Admin/Index");
        }

        public ActionResult Add(string deviceName, double memoryValue, string userName)
        {
            User tempUser = _usersRepository.Get(userName);
            foreach (Device device in _devicesRepository.Get())
            {
                if (device.Name == deviceName)
                {
                    return View("~/Views/Admin/SameNameDevice.cshtml");
                }
            }
            Device tempDevice = new Device() { Name = deviceName, Memory = memoryValue, User = tempUser };
            _devicesRepository.Create(tempDevice);
            tempUser.Devices.Add(tempDevice);
            return Redirect("/Admin/Index");
        }
    }
}