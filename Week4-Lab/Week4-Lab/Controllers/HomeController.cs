using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4_Lab.Models;

namespace Week4_Lab.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Post post = new Post();
            post.PostDate = DateTime.Now;
            var thePosts = GetPosts();
            post.ID = thePosts.Max(x=>x.ID) + 1;            
            return View(post);
        }
        
        [HttpPost]
        public ActionResult Create(Post newPost)
        {
            List<Post> posts = GetPosts();
            posts.Add(newPost);
            HttpContext.Application["myPosts"] = posts;
            return RedirectToAction("ViewPost");
        }

        public ActionResult ViewPost()
        {
            List<Post> posts = GetPosts();
            return View(posts.Last());
        }

        public List<Post> GetPosts()
        {
            List<Post> thePosts = (List<Post>)HttpContext.Application["myPosts"];
            if (thePosts == null)
            {
                thePosts = new List<Post>();
                thePosts.Add(new Post { ID = 1, Author = "Scott Ferguson", PostDate = DateTime.Now, Title = "Amigos", Text = "< p >Now, when you do this without getting punched in the chest, you'll have more fun. I'm half machine.I'm a monster. Army had half a day. Across from where?</p> < h2 > Meat the Veals</ h2 > < p > Marry me.It's called 'taking advantage.' It's what gets you ahead in life.No!I was ashamed to be SEEN with you.I like being with you.I've opened a door here that I regret.</p>< ul >< li > Army had half a day.</ li >< li > Say goodbye to these, because it's the last time!</li>< li > That's why you always leave a note!</li>< li > Really ? Did nothing cancel ?</ li ></ ul >< h3 > Let 'Em Eat Cake</h3>< p > I'm afraid I just blue myself. Oh, you're gonna be in a coma, all right.No, I did not kill Kitty.However, I am going to oblige and answer the nice officer's questions because I am an honest man with no secrets to hide. No! I was ashamed to be SEEN with you. I like being with you. Did you enjoy your meal, Mom? You drank it fast enough. Guy's a pro.</ p >< h4 > Good Grief!</ h4 >< p > Say goodbye to these, because it's the last time! We just call it a sausage. I don't understand the question, and I won't respond to it. I hear the jury's still out on science.</ p >< ol >< li > I hear the jury's still out on science.</li>< li > Across from where?</ li ></ ol >< h5 > Ready, Aim, Marry Me</ h5 >< p > It's a hug, Michael. I'm hugging you.It's called 'taking advantage.' It's what gets you ahead in life.That's why you always leave a note!</p>" });
                HttpContext.Application["myPosts"] = thePosts;
            }
            return thePosts;
        }

    }
}