using System;
using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ManageDevicesViewModel manageDevicesViewModel = new ManageDevicesViewModel();
        //private readonly IUsersRepository _usersRepository;
        //private readonly IDevicesRepository _devicesRepository;
        StatusBar statusBar = new StatusBar();
        public AdminController(IUsersRepository usersRepository, IDevicesRepository devicesRepository)
        {
            manageDevicesViewModel.devices = devicesRepository;
            manageDevicesViewModel.users = usersRepository;
        }

        [HttpPost]
        public RedirectResult AddUser(string name)
        {
            manageDevicesViewModel.users.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            return Redirect("/Admin/Index");
        }

        public RedirectResult DeleteUser()
        {
            Guid id = ViewBag.userToDelete;
            manageDevicesViewModel.users.Delete(id);
            return Redirect("/Admin/Index");
        }

        public RedirectResult AddDevice(string deviceName, double memoryValue, string userName)
        {
            User tempUser = manageDevicesViewModel.users.Get(userName);
            if (!(tempUser == null))
            {
                manageDevicesViewModel.devices.Create(new Device
                {
                    deviceName = deviceName,
                    memory = memoryValue,
                    user = tempUser
                });
                return Redirect("/Admin/Index");
            }
            return Redirect("/Admin/NotExistingName");
        }

        public ActionResult NotExistingName()
        {
            return View("~/Views/Admin/NotExistingName.cshtml");
        }

        public ActionResult Index()
        {
            var users = manageDevicesViewModel.users.Get();
            var devices = manageDevicesViewModel.devices.Get();
            ViewBag.NumberOfDevices = devices.Length;
            ViewBag.NumberOfUsers = users.Length;
            ViewBag.NumberOfVideos = 0;
            return View(manageDevicesViewModel);
        }

    }
}