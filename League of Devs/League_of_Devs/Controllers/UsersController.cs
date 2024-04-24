using Microsoft.AspNetCore.Mvc;

namespace League_of_Devs.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
