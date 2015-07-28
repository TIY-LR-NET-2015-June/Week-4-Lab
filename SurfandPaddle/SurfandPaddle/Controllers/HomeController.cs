using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurfandPaddle.Models;

namespace SurfandPaddle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            // CREATE THE FOUR INITIAL POSTS
            if (posts == null)
            {
                posts = new List<Posts>();
                Posts postOne = new Posts();
                postOne.ID = 0;
                postOne.Title = "Augnebum Lesuno";
                postOne.Text = "et ullamcorper nibh, aliquet aliquam mi.Sed nec vehicula arcu, non egestas felis. Aliquam et risus ornare sem mattis luctus.Suspendisse sed odio non turpis pulvinar eleifend.Aliquam pretium lacus a magna venenatis aliquet.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Etiam scelerisque imperdiet libero, nec pellentesque magna scelerisque ac. Duis ac lorem at ipsum lobortis bibendum.Sed ut orci tincidunt, suscipit tellus eget, ultricies augue.Vivamus placerat euismod dolor eu porttitor. Curabitur tristique, metus in vehicula gravida, orci ante pellentesque velit, vel pulvinar libero ante vitae arcu. Integer quis tellus quis odio mattis vulputate eget ac nulla. Etiam at risus lacus. Ut sit amet libero vestibulum, egestas mi quis, imperdiet eros. Cras tincidunt lacus in euismod vestibulum. Curabitur egestas diam in cursus sodales. In facilisis orci quis nisi commodo, quis pharetra arcu luctus.Aenean lobortis vel justo id tincidunt. Praesent vel erat rhoncus, congue elit accumsan, congue nulla.Phasellus turpis turpis, tristique sit amet aliquam eget, congue ac ligula.Sed vulputate gravida tellus, sed blandit justo posuere ac. Aliquam sit amet commodo est, sit amet semper augue. Nullam eget diam et nulla feugiat fermentum.Vivamus nec accumsan purus. ";
                postOne.Image = "~/content/1.jpg";
                posts.Add(postOne);
                Posts postTwo = new Posts();
                postTwo.ID = 0;
                postTwo.Title = "consectetur Duis";
                postTwo.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Duis sit amet ullamcorper nibh, aliquet aliquam uspendisse sed odio non turpis pulvinar eleifend.Aliquam pretium lacus a magna Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Etiam scelerisque imperdiet libero, nec pellentesque magna scelerisque ac. Duis ac lorem at ipsum lobortis bibendum.Sed ut orci tincidunt, suscipit tellus eget, ultricies augue.Vivamus placerat euismod dolor eu porttitor. Curabitur tristique, metus in vehicula gravida, orci ante pellentesque velit, vel pulvinar libero ante vitae arcu. Integer quis tellus quis odio mattis vulputate eget ac nulla. Etiam at risus lacus. Ut sit amet libero vestibulum, egestas mi quis, imperdiet eros. Cras tincidunt lacus in euismod vestibulum. Curabitur egestas diam in cursus sodales. In facilisis orci quis nisi commodo, quis pharetra arcu luctus.Aenean lobortis vel justo id tincidunt. Praesent vel erat rhoncus, congue elit accumsan, congue nulla.Phasellus turpis turpis, tristique sit amet aliquam eget, congue ac ligula.Sed vulputate gravida tellus, sed blandit justo posuere ac. Aliquam sit amet commodo est, sit amet semper augue. Nullam eget diam et nulla feugiat fermentum.Vivamus nec accumsan purus. ";
                postTwo.Image = "~/content/2.png";
                posts.Add(postTwo);
                Posts postThree = new Posts();
                postThree.ID = 0;
                postThree.Title = "Aliquam venenatis";
                postThree.Text = "Lorem ipsum dolor sit amet, consectm mattis luctus.Suspendisse sed odio non turpis pulvinar eleifend.Aliquam pretium lacus a magna venenatis aliquet.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Etiam scelerisque imperdiet libero, nec pellentesque magna scelerisque ac. Duis ac lorem at ipsum lobortis bibendum.Sed ut orci tincidunt, suscipit tellus eget, ultricies augue.Vivamus placerat euismod dolor eu porttitor. Curabitur tristique, metus in vehicula gravida, orci ante pellentesque velit, vel pulvinar libero ante vitae arcu. Integer quis tellus quis odio mattis vulputate eget ac nulla. Etiam at risus lacus. Ut sit amet libero vestibulum, egestas mi quis, imperdiet eros. Cras tincidunt lacus in euismod vestibulum. Curabitur egestas diam in cursus sodales. In facilisis orci quis nisi commodo, quis pharetra arcu luctus.Aenean lobortis vel justo id tincidunt. Praesent vel erat rhoncus, congue elit accumsan, congue nulla.Phasellus turpis turpis, tristique sit amet aliquam eget, congue ac ligula.Sed vulputate gravida tellus, sed blandit justo posuere ac. Aliquam sit amet commodo est, sit amet semper augue. Nullam eget diam et nulla feugiat fermentum.Vivamus nec accumsan purus. ";
                postThree.Image = "~/content/3.jpg";
                posts.Add(postThree);
                Posts postFour = new Posts();
                postFour.Image = "~/content/4.jpg";
                postFour.ID = 0;
                postFour.Title = "nibh dolor";
                postFour.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Duis sit amet ullamcorper nibh, aliquet aliquam mi.Sed nec vehicula arcu, non egestas felis. Aliquam et risus ornare sem mattis luctus.Suspendisse sed odio non mentum.Vivamus nec accumsan purus. ";
                posts.Add(postFour);
                HttpContext.Application["Posts"] = posts;
            }
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ViewPosts(int id)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            return View(posts.ElementAt(id));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Posts post)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            post.ID = posts.Count + 1;
            posts.Add(post);
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Posts post)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            posts[post.ID] = post;
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Posts post)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            posts.Remove(post);
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("Index");
        }
    }
}