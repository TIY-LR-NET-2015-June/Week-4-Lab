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
            if (((List<Article>)HttpContext.Application["ArticleList"]).Count < 5 || ((List<Article>)HttpContext.Application["AdList"]) == null)
            {
                return RedirectToAction ("Main");
            }
            return View(HttpContext.Application["ArticleList"]);
        }

        // GET: Article/Details/5
        public ActionResult Details(string id)
        {
            List<Article> ArticleList = (List<Article>)HttpContext.Application["ArticleList"];
            Article a = ((List<Article>)HttpContext.Application["ArticleList"]).Find(x => x.Id == id);
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
           
            a.Id = a.Headline.Replace(' ','_');
            if (((List<Article>)HttpContext.Application["ArticleList"]).Find(x=>x.Id == a.Id) != null)
            {
                a.Id = a.Id + DateTime.Now.Millisecond.ToString();
            }
            if (a.isAdvertisement)
            {
                ((List<Article>)HttpContext.Application["AdList"]).Add(a);
            }
            else
            {
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(a);
            }
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
        public ActionResult Edit(string id)
        {
            Article a = ((List<Article>)HttpContext.Application["ArticleList"]).Find(x => x.Id == id);
            return View(a);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Article editedArticle)
        {
            
            try
            {
                // TODO: Add update logic here
                Article oldArticle = ((List<Article>)HttpContext.Application["ArticleList"]).Find(x => x.Id == id);
                ((List<Article>)HttpContext.Application["ArticleList"]).Remove(oldArticle);
                editedArticle.Id = id;
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(editedArticle);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(string id)
        {

            Article a = ((List<Article>)HttpContext.Application["ArticleList"]).Find(x => x.Id == id);
            return View(a);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Article article)
        {
            try
            {
                // TODO: Add delete logic here
                Article a = ((List<Article>)HttpContext.Application["ArticleList"]).Find(x => x.Id == id);
                ((List<Article>)HttpContext.Application["ArticleList"]).Remove(a);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Main()
        {
            if (HttpContext.Application["ArticleList"] == null)
            {
                List<Article> ArticleList = new List<Article>();
                HttpContext.Application["ArticleList"] = ArticleList;
                List<Article> AdList = new List<Article>();
                HttpContext.Application["AdList"] = ArticleList;


                Article art1 = new Article();
                Article art2 = new Article();
                Article art3 = new Article();
                Article art4 = new Article();
                Article art5 = new Article();
                Article ad1 = new Article();
                art1.Author = "John Doe";
                art1.Headline = "A Fantastic Engaging Headline Goes Here!";
                art1.Picture = "~/Content/assets/bottles.jpg";
                art1.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art1.AuthorPicture = "/Content/assets/mike.jpg";
                art1.Date = DateTime.Today;
                art1.isAdvertisement = false;
                art1.Id = art1.Headline.Replace(' ','_');

                art2.Author = "Tom Slick";
                art2.Headline = "Another Cool Post!";
                art2.Picture = "/Content/assets/beer.jpg";
                art2.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art2.AuthorPicture = "/Content/assets/mike.jpg";
                art2.Date = DateTime.Today;
                art2.isAdvertisement = false;
                art2.Id = art2.Headline.Replace(' ','_');

                art3.Author = "Janet Reno";
                art3.Headline = "A Somewhat Longer Post Title";
                art3.Picture = "/Content/assets/zachgalifanakis.jpg";
                art3.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art3.AuthorPicture = "/Content/assets/mike.jpg";
                art3.Date = DateTime.Today;
                art3.isAdvertisement = false;
                art3.Id = art3.Headline.Replace(' ','_');

                art4.Author = "Janet Reno";
                art4.Headline = "The Title is";
                art4.Picture = "/Content/assets/surfboarddude.jpg";
                art4.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art4.AuthorPicture = "/Content/assets/mike.jpg";
                art4.Date = DateTime.Today;
                art4.isAdvertisement = false;
                art4.Id = art4.Headline.Replace(' ','_');

                art5.Author = "Janet Reno";
                art5.Headline = "Once again into the breach";
                art5.Picture = "/Content/assets/bottles.jpg";
                art5.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art5.AuthorPicture = "/Content/assets/mike.jpg";
                art5.Date = DateTime.Today;
                art5.isAdvertisement = false;
                art5.Id = art5.Headline.Replace(' ','_');

                ad1.Author = "Janet Reno";
                ad1.Headline = "And yet another interesting read";
                ad1.Picture = "/Content/assets/paddleboarder.jpg";
                ad1.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.

Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.

Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.

Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                ad1.AuthorPicture = "/Content/assets/mike.jpg";
                ad1.Date = DateTime.Today;
                ad1.isAdvertisement = true;
                ad1.Id = ad1.Headline.Replace(' ','_');



                ((List<Article>)HttpContext.Application["ArticleList"]).Add(art1);
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(art2);
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(art3);
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(art4);
                ((List<Article>)HttpContext.Application["ArticleList"]).Add(art5);
                ((List<Article>)HttpContext.Application["AdList"]).Add(ad1);
            }

            ((List<Article>)HttpContext.Application["ArticleList"]).OrderBy(x => x.Date).Reverse();
            ((List<Article>)HttpContext.Application["AdList"]).OrderBy(x => x.Date).Reverse();
            List<Article> DisplayList = new List<Article>();
            for (int i = 1; i < 5; i++)
            {
                Article nextArticle = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(i);
                DisplayList.Add(nextArticle);
                
            }
            ViewBag.Headline1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).Headline;
            ViewBag.Author1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).Author;
            ViewBag.AuthorPicture1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).AuthorPicture;
            ViewBag.Date1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).Date;
            ViewBag.Text1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).Text;
            ViewBag.Picture1 = ((List<Article>)HttpContext.Application["ArticleList"]).ElementAt(0).Picture;

            ViewBag.Headline2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).Headline;
            ViewBag.Author2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).Author;
            ViewBag.AuthorPicture2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).AuthorPicture;
            ViewBag.Date2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).Date;
            ViewBag.Text2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).Text;
            ViewBag.Picture2 = ((List<Article>)HttpContext.Application["AdList"]).ElementAt(0).Picture;


            return View(DisplayList);
        }
        
    }
}
