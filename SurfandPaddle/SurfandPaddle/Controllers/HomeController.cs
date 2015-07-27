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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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
            List<Posts> posts = new List<Posts>() { (Posts)HttpContext.Application["Posts"] };
            post.ID = posts.Count + 1;
            posts.Add(post);
            HttpContext.Application["Posts"] = posts;
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Posts post)
        {
            List<Posts> posts = new List<Posts>() { (Posts)HttpContext.Application["Posts"] };
            posts[post.ID] = post;
            HttpContext.Application["Posts"] = posts;
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Posts post)
        {
            List<Posts> posts = new List<Posts>() { (Posts)HttpContext.Application["Posts"] };
            posts.Remove(post);
            HttpContext.Application["Posts"] = posts;
            return View();
        }
    }
}