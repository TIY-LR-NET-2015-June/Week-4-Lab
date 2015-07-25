using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View(HttpContext.Application["ArticleList"]);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
            Article a = ArticleList.Find(x => x.Id == id);
            return View(a);
        }

        // GET: Article/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(Article a)
        {
            if(!ModelState.IsValid)
            {
                return View(a);
            }
            if (HttpContext.Application["ArticleList"] == null)
            {
                List<Article> ArticleList = new List<Article>();
                HttpContext.Application["ArticleList"] = ArticleList;
            }
            if (HttpContext.Application["ArticleCounter"] == null)
            {
                HttpContext.Application["ArticleCounter"] = 0;
            }
            HttpContext.Application["ArticleCounter"] = (int)HttpContext.Application["ArticleCounter"] + 1;
            a.Id = (int)HttpContext.Application["ArticleCounter"];
            ((List<Article>)HttpContext.Application["ArticleList"]).Add(a);
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(HttpContext.Application["ArticleList"]);
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
            Article a = ArticleList.Find(x => x.Id == id);
            return View(a);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Article editedArticle)
        {
            List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
            Article oldArticle = ArticleList.Find(x => x.Id == id);
            ArticleList.Remove(oldArticle);
            editedArticle.Id = id;
            ArticleList.Add(editedArticle);
            HttpContext.Application["ArticleList"] = ArticleList;
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

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
            Article a = ArticleList.Find(x => x.Id == id);
            return View(a);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                // TODO: Add delete logic here
                List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
                Article a = ArticleList.Find(x => x.Id == id);
                ArticleList.Remove(a);
                HttpContext.Application["ArticleList"] = ArticleList;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
