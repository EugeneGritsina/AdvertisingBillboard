using System;
using AdvertisingBillboard.Domain;
using AdvertisingBillboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUsersRepository _usersRepository;
        public AdminController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public ActionResult AddUser(string name)
        {
            _usersRepository.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = name
            }); ;
            return View("Index");
        }

        public ActionResult Index()
        {
            _usersRepository.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = "A1"
            });

            _usersRepository.Create(new User
            {
                Id = Guid.NewGuid(),
                Name = "A2"
            });

            var users = _usersRepository.Get();

            var statusBar = new StatusBar
            {
                NumberOfDevices = 1,
                NumberOfUsers = users.Length,
                NumberOfVideos = 3
            };
            return View(statusBar);
        }

    }
}