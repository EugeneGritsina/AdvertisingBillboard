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

        public IActionResult Index(string name)
        {
            //userName не передается через список параметров, а также нет возможности подтянуть ее через viewBag в контроллере Users
            var users = _usersRepository.Get();
            foreach (User user in users)
            {
                if (name.Equals(user.Name))
                    return View(user);
            }
            return View();
        }
    }
}