using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4.Models;

namespace Week4.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View(HttpContext.Application["Posts"]);
        }

        // GET: Post/Details/5
        public ActionResult Details(Guid id)
        {
            var posts = (List<Post>)HttpContext.Application["Posts"];
            var post = posts.First(x => x.Id == id);
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToRoute("Login");
            }

            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post p)
        {
            try
            {
                if (Session["CurrentUser"] == null)
                {
                    return RedirectToRoute("Login");
                }

                p.Author = (SiteUser)Session["CurrentUser"];
                p.DateTimeSubmitted = DateTime.Now;
                var posts = (List<Post>) HttpContext.Application["Posts"];
                posts.Add(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Post/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            List<Post> p = (List<Post>)HttpContext.Application["Posts"];
            Post thisPost = p.First(x => x.Id == id);
            SiteUser author = thisPost.Author;
            if (author != HttpContext.Session["CurrentUser"])
            {
                return RedirectToAction("Denied", "SiteUser");
            }
            return View(thisPost);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(Post post)
        {
            try
            {
                List<Post> posts = (List<Post>)HttpContext.Application["Posts"];
                posts.Remove(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
