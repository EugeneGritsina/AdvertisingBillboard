using System;
using System.Collections.Generic;
using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Domain.Services;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ManageDevicesViewModel manageDevicesViewModel = new ManageDevicesViewModel();
        private readonly UserService userService = new UserService();
        //private readonly IUsersRepository _usersRepository;
        //private readonly IDevicesRepository _devicesRepository;
        StatusBar statusBar = new StatusBar();
        public AdminController(IUsersRepository _usersRepository, IDevicesRepository _devicesRepository, IVideosRepository _videosRepository, UserService _userService)
        {
            manageDevicesViewModel.devices = _devicesRepository;
            manageDevicesViewModel.users = _usersRepository;
            manageDevicesViewModel.videos = _videosRepository;
            userService = _userService;
        }

        [HttpPost]
        public RedirectResult AddUser(string name)
        {
            manageDevicesViewModel.users.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                devices = new List<Device>()
            });

            return Redirect("/Admin/Index");
        }

        [HttpPost, ActionName("delete")]
        public RedirectResult Delete(Guid id)
        {
            User userToDelete = manageDevicesViewModel.users.Get(id);
            int amountOfDevicesUserHas = userService.GetDevices(userToDelete).Length;
            Device[] userToDeleteDevices = userService.GetDevices(userToDelete);

            userService.DeleteDevices(userToDeleteDevices, manageDevicesViewModel.devices, amountOfDevicesUserHas);

            manageDevicesViewModel.users.Delete(id);
            return Redirect("~/Admin/Index");
        }

        public RedirectResult AddDevice(string deviceName, double memoryValue, string userName)
        {
            User tempUser = manageDevicesViewModel.users.Get(userName);
            if (!(tempUser == null))
            {
                Device tempDevice = new Device(){ deviceName = deviceName, memory = memoryValue, user = tempUser };
                manageDevicesViewModel.devices.Create(tempDevice);
                tempUser.devices.Add(tempDevice);
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
            var videos = manageDevicesViewModel.videos.Get();
            ViewBag.NumberOfDevices = devices.Length;
            ViewBag.NumberOfUsers = users.Length;
            ViewBag.NumberOfVideos = videos.Length;
            return View(manageDevicesViewModel);
        }

        public ActionResult UploadVideo(string videoAddress, string videoName, string deviceName)
        {
            Video video = new Video()
            {
                name = videoName,
                address = videoAddress,
                device = manageDevicesViewModel.devices.Get(deviceName)
            };
            manageDevicesViewModel.videos.AddVideo(video);
            return Redirect("/Admin/Index");
        }

    }
}