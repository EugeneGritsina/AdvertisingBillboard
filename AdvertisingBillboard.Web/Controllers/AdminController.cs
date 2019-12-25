using System;
using System.Collections.Generic;
using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IDevicesRepository _devicesRepository;
        private readonly IVideosRepository _videosRepository;

        public AdminController(
            IUsersRepository usersRepository,
            IDevicesRepository devicesRepository,
            IVideosRepository videosRepository)
        {
            _usersRepository = usersRepository;
            _devicesRepository = devicesRepository;
            _videosRepository = videosRepository;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var users = _usersRepository.Get();
            var devices = _devicesRepository.Get();
            var videos = _videosRepository.Get();
            
            var usersViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                usersViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Devices = _devicesRepository.Get(user.Id)
                });
            }
            
            var vm = new AdministratorPageViewModel
            {
                Users = usersViewModels.ToArray(),
                Devices = devices,
                Videos = videos
            };
            
            return View(vm);
        }

        [HttpPost]
        public RedirectResult AddUser(string name)
        {
            _usersRepository.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = name
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

        // [HttpPost]
        // public RedirectResult DeleteVideo(string name)
        // {
        //     var videoToDelete = _videosRepository.
        //     var videoToDelete = _videosRepository.Delete()
        //     _videoService.Delete();
        //     Video video = manageDevicesViewModel.videos.Get(name);
        //     videoService.Delete(video,manageDevicesViewModel.videos);
        //     return Redirect("~/Admin/Index");
        // }
        
        public IActionResult AddDevice(string deviceName, double memoryValue, string userName)
        {
            var user = _usersRepository.Get(userName);
            if (user == null)
            {
                return Redirect("/Admin/NotExistingName");
            }
            
            Device device = new Device
            {
                Name = deviceName,
                Memory = memoryValue,
                User = user
            };
            
            _devicesRepository.Create(device);
            return Redirect("~/Admin/Index");
        }
        
        

        public ActionResult NotExistingName()
        {
            return View("~/Views/Admin/NotExistingName.cshtml");
        }
        

        public ActionResult UploadVideo(string videoAddress, string videoName, string deviceName)
        {
            var device = _devicesRepository.Get(deviceName);
            Video video = new Video
            {
                Name = videoName,
                Address = videoAddress,
                Device = device
            };
            
            
            _videosRepository.Create(video);
            return Redirect("/Admin/Index");
        }

    }
}