using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpPost]
        public ActionResult Add(string name)
        {
            foreach (User user in _usersRepository.Get())
            {
                if (user.Name == name)
                {
                    return View("~/Views/Admin/SameNameUser.cshtml");
                }
            }
            _usersRepository.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Devices = new List<Device>()
            });

            return Redirect("/Admin/Index");
        }

        [HttpPost]
        [ActionName("delete")]
        public RedirectResult Delete(Guid id)//delete user and his videos
        {
            _usersRepository.Delete(id);
            _devicesRepository.Delete(id);
            return Redirect("~/Admin/Index");
        }
    }
}