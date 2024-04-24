using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using League_of_Devs.Models;
using League_of_Devs.DateBase;

namespace League_of_Devs.Controllers
{
    public class postController : Controller
    {
        public IActionResult post()
        {
            return View();
        }
        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add(PostsModel post_data)
        {
            using Data data = new Data();
            string wwwpath = HomeController.WebRootPath;
            string path = Path.Combine(wwwpath, "src");
            if (post_data.ThumbImage != null)
            {
                string filename = post_data.ThumbImage.FileName;
                string filedir = Path.Combine(path, filename);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!System.IO.File.Exists(filedir))
                {
                    using (FileStream fs = new FileStream(filedir, FileMode.Create))
                    {
                        post_data.ThumbImage.CopyTo(fs);
                    }
                }
                post_data.thumbimage = "src/" + filename;
            }
            if (post_data.Image != null)
            {
                List<string> filename = new List<string>();
                foreach(var img in post_data.Image)
                {
                    string str = img.FileName;
                    string filedir = Path.Combine(path, str);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (!System.IO.File.Exists(filedir))
                    {
                        using (FileStream fs = new FileStream(filedir, FileMode.Create))
                        {
                            img.CopyTo(fs);
                        }
                    }
                    post_data.image += "src/" + str + "S#S";
                }
            }
            post_data.AccountId = loginController.User.Id;
            data.posts.Add(post_data);
            data.SaveChanges();
            post_data.image = "";
            return View();
        }


        public IActionResult userinfo()
        {
            return View();
        }
    }
}
