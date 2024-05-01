using League_of_Devs.Models;
using League_of_Devs.DateBase;
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
            using Data data = new Data();
            if(loginController.User != null) ViewBag.posts = data.posts.Where(x => x.AccountId == loginController.User.Id).ToList();
            else ViewBag.posts = data.posts.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(PostsModel name)
        {

            using Data data = new Data();
            ViewBag.name = data.accounts.Where(x => x.Name.Contains(name.Title)).ToList();
            if (loginController.User != null) ViewBag.posts = data.posts.Where(x => x.AccountId == loginController.User.Id).ToList();
            else ViewBag.posts = data.posts.ToList();
            return View();
        }
    }
}