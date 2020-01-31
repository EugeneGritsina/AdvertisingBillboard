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

        [HttpGet]
        public PartialViewResult Users()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Videos()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Devices()
        {
            return PartialView();
        }

        public ActionResult NotExistingName()
        {
            return View("~/Views/Admin/NotExistingName.cshtml");
        }
    }
}