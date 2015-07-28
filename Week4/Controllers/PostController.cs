using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4.Models;
using static Week4.MvcApplication;
namespace Week4.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return View(Posts);
        }

        public ActionResult Details(Guid id)
        {
            return View(Posts.First(x => x.Id == id));
        }

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
                p.Author = (SiteUser)Session["CurrentUser"];
                p.DateTimeSubmitted = DateTime.Now;
                Posts.Add(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(401);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Posts.First(x => x.Id == id).Author == (SiteUser)Session["CurrentUser"])
            {
                return View(Posts.First(x => x.Id == id));
            }
            return RedirectToAction("Denied", "SiteUser");
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
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
