using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurfandPaddle.Models;

namespace SurfandPaddle.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult ViewPosts()
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            return View(posts);
        }
        public ActionResult ViewAPost(int id)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            Posts post = posts.Find(aPost => aPost.ID == id);
            return View(post);
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
            post.ID = posts.Last().ID + 1;
            posts.Add(post);
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            Posts post = posts.Find(aPost => aPost.ID == id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Posts post)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            posts[post.ID] = post;
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(Posts post)
        {
            List<Posts> posts = (List<Posts>)HttpContext.Application["Posts"];
            posts.RemoveAll(aPost => aPost.ID == post.ID);
            posts.RemoveAll(aPost => aPost == null);
            foreach (Posts aPost in posts)
            {
                int index = posts.FindIndex(a => a.ID == aPost.ID);
                aPost.ID = index;
            }
            HttpContext.Application["Posts"] = posts;
            return RedirectToAction("ViewPosts");
        }
    }
}