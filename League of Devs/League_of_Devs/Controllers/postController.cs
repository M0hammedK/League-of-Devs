using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using League_of_Devs.Models;
using League_of_Devs.DateBase;
using System.Xml.Linq;

namespace League_of_Devs.Controllers
{
    public class postController : Controller
    {
        public IActionResult post(string page)
        {
            using Data data = new Data();
            ViewBag.post = data.posts.Where(x => x.Id == Convert.ToInt32(page)).ToList().First();
            return View();
        }

        public IActionResult add(string page)
        {
            if (page != null)
            {
                using Data data = new Data();
                ViewBag.post = data.posts.Where(x => x.Id == Convert.ToInt32(page)).First();
                TempData["post_id"] = page;
            }
            return View();
        }
        public IActionResult userinfo()
        {

            return View();
        }

        [HttpPost]
        public IActionResult add(PostsModel post_data, string type)
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
                foreach (var img in post_data.Image)
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
            if (type == "Add")
            {
                data.posts.Add(post_data);
            }
            else
            {
                PostsModel post = data.posts.Where(post => post.Id == Convert.ToInt32(TempData["post_id"])).First();
                post.image = post_data.image;
                post.Title = post_data.Title;
                post.Summary = post_data.Summary;
                post.thumbimage = post_data.thumbimage;
                post.Content = post_data.Content;
                data.posts.Update(post);
            }
            data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public IActionResult userinfo(AccountsModel account)
        {
            using Data data = new Data();
            loginController.User.Name = account.Name;
            loginController.User.Bio = account.Bio;
            loginController.User.Experience = account.Experience;
            loginController.User.Availability = account.Availability;
            data.accounts.Update(loginController.User);
            data.SaveChanges();
            ViewBag.user = loginController.User;
            return View();
        }
            // Other actions...

        [HttpGet]
        public IActionResult delete(string id)
        {
            using Data data = new Data();

            var postToDelete = data.posts.Find(int.Parse(id));


            // Check if the post exists
            if (postToDelete != null)
            {
                // Delete the post
                data.posts.Remove(postToDelete);
                data.SaveChanges();
            }

            // Redirect to the home page after deletion
            return RedirectToAction("Index", "Home");
        }
    }
}
