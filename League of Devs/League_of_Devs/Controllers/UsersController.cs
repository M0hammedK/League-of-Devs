using Microsoft.AspNetCore.Mvc;
using League_of_Devs.DateBase;

namespace League_of_Devs.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult User(string page)
        {
            using Data data = new Data();
            ViewBag.posts = data.posts.Where(x => x.AccountId == Convert.ToInt32(page)).ToList();
            ViewBag.user = data.accounts.Where(x => x.Id == Convert.ToInt32(page)).ToList().First();
            return View();
        }
    }
}
