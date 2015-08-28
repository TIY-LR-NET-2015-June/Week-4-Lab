using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week4Lab.Models;

namespace Week4Lab.Controllers
{
    public class PostController : Controller
    {
        public List<Post> GetPosts()
        {
            List<Post> posts = (List<Post>)Session["BlogPosts"];
            if (posts == null)
            {
                posts = new List<Post>();
                posts.Add(new Post() { Author = "Jason Williams", Id = 1, Text = "BLAFfajkdfasl;kfasklfk", Title = "5 Reasons to Blah Blah", DatePosted = DateTime.Now });
                posts.Add(new Post() { Author = "Jason Williams", Id = 2, Text = "BLAFBLAH BLAHkfasklfk", Title = "10 Reasons to Blah Blah", DatePosted = DateTime.Now.AddMonths(-1) });
                posts.Add(new Post() { Author = "Dainel Pollock", Id = 3, Text = "fadfff;kfasklfk", Title = "1 Reason to Blah Blah", DatePosted = DateTime.Now.AddDays(-5) });
                SavePosts(posts);
            }

            return posts;
        }

        public void AddPost(Post p)
        {
            var posts = GetPosts();

            p.Id = posts.Max(x => x.Id) + 1;

            posts.Add(p);

            SavePosts(posts);
        }

        public void SavePosts(List<Post> Posts)
        {
            Session["BlogPosts"] = Posts;
        }

        // GET: Post
        public ActionResult Index()
        {
            return View(GetPosts());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {

            return View(GetPosts().FirstOrDefault(x => x.Id == id));
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post newPost)
        {
            if (!ModelState.IsValid)
            {
                return View(newPost);
            }
            try
            {
                // TODO: Add insert logic here
                newPost.DatePosted = DateTime.Now;
                AddPost(newPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)

        {
            var post = GetPosts().FirstOrDefault(x => x.Id == id);

            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post edittedPost)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //do the update with edittedpost
                    var posts = GetPosts();
                    var post = posts.FirstOrDefault(x => x.Id == edittedPost.Id);
                    posts.Remove(post);
                    posts.Add(edittedPost);
                    SavePosts(posts);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(edittedPost);
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = GetPosts().FirstOrDefault(x => x.Id == id);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var posts = GetPosts();
            var post = posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                posts.Remove(post);
                SavePosts(posts);
            }

            return RedirectToAction("Index");
        }
    }
}
