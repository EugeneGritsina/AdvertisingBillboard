using AdvertisingBillboard.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AuthController :Controller
    {
        private readonly IUsersRepository _usersRepository;
        
        public AuthController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName)
        {
            return View();
        }


        public ActionResult EnterAsUser(string userName)
        {
            foreach (var user in _usersRepository.Get())
            {
                if (userName.ToLower().Equals(user.Name.ToLower())) {
                    ViewBag.userName = userName;
                    return RedirectToAction("Get", "Users", new { name = userName });
                }
            }
            return View("~/Views/Shared/ErrorWrongName.cshtml");
        }
    }
}