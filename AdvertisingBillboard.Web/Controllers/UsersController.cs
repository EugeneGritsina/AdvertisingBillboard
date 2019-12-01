using AdvertisingBillboard.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboard.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            var users = _usersRepository.Get();
            return View(users);
        }
    }
}