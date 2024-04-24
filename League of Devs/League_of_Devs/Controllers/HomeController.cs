  using League_of_Devs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace League_of_Devs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IWebHostEnvironment hostEnvironment, ILogger<HomeController> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public static string WebRootPath;

        public IActionResult Index()
        {
            WebRootPath = this._hostEnvironment.WebRootPath;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}