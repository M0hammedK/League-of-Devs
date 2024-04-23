using Microsoft.AspNetCore.Mvc;

namespace League_of_Devs.Controllers
{
	public class loginController : Controller
	{
		public IActionResult login()
		{
			return View();
		}
	}
}
