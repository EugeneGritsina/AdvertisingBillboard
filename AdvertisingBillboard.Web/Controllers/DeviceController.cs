using AdvertisingBillboard.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDevicesRepository _devicesRepository;

        public DeviceController(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        [HttpPost]
        public RedirectResult Delete(string name)//delete device
        {
            _devicesRepository.Delete(name);
            return Redirect("~/Admin/Index");
        }
    }
}