using Microsoft.AspNetCore.Mvc;

namespace League_of_Devs.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
