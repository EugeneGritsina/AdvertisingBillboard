using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class AuthController :Controller
    {
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
    }
}