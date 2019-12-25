using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IDevicesRepository _devicesRepository;

        public UsersController(
            IUsersRepository usersRepository,
            IDevicesRepository devicesRepository)
        {
            _usersRepository = usersRepository;
            _devicesRepository = devicesRepository;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            var user = _usersRepository.Get(name);
            var devices = _devicesRepository.Get(user.Id);

            var vm = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Devices = devices
            };
            
            return View(vm);
        }
    }
}