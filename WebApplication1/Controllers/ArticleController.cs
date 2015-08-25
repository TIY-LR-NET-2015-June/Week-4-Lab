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
        public List<Article> PullArticleList()
        {
            if (HttpContext.Application["ArticleList"] == null)
            {
                List<Article> list = new List<Article>();
                HttpContext.Application["ArticleList"] = list;
            }
            return (List<Article>)HttpContext.Application["ArticleList"];
        }
        public List<Article> PullAds()
        {
            if (HttpContext.Application["AdList"] == null)
            {
                List<Article> list = new List<Article>();
                HttpContext.Application["AdList"] = list;
            }
            return (List<Article>)HttpContext.Application["AdList"];
        }
        public void StoreArticleList(List<Article> list)
        {
            list.OrderByDescending(x => x.Date);
            HttpContext.Application["ArticleList"] = list;
        }
        public void StoreAds(List<Article> list)
        {
            list.OrderByDescending(x => x.Date);
            HttpContext.Application["AdList"] = list;
        }
        

        // GET: Article
        public ActionResult Index()
        {
            if (PullArticleList() == null)
            {
                Seed();
            }
            
            return View(PullArticleList());
        }

        // GET: Article/Details/5
        public ActionResult Details(Guid id)
        {
           
            Article a = (PullArticleList()).Find(x => x.Id == id);
            if (a == null)
            {
                Seed();
            }
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
           
            a.Id = Guid.NewGuid();
            List<Article> list = PullArticleList();
            List<Article> adList = PullAds();
            
            if (a.isAdvertisement)
            {
                adList.Add(a); 
            }
            else
            {
                list.Add(a);
            }
            StoreArticleList(list);
            StoreAds(adList);
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(a);
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(Guid id)
        {
            Article a = (PullArticleList()).Find(x => x.Id == id);
            if (a == null)
            {
                Seed();
            }
            return View(a);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Article editedArticle)
        {
            
            try
            {
                // TODO: Add update logic here
                List<Article> list = PullArticleList();
                Article oldArticle = (list).Find(x => x.Id == id);
                (list).Remove(oldArticle);
                editedArticle.Id = id;
                (list).Add(editedArticle);
                StoreArticleList(list);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(Guid id)
        {

            Article a = (PullArticleList()).Find(x => x.Id == id);
            return View(a);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, Article article)
        {
            try
            {
                // TODO: Add delete logic here
                List<Article> list = PullArticleList();
                Article a = (list).Find(x => x.Id == id);
                (list).Remove(a);
                StoreArticleList(list);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Main()
        {
            Seed();
            ViewBag.Article1 = PullArticleList().First();
            ViewBag.Ad1 = PullAds().First();
            return View(PullArticleList().Skip(1).Take(4));
        }
        public void Seed()
        {
            List<Article> list = new List<Article>();
            list = PullArticleList();
            List<Article> adList = new List<Article>();
            adList = PullAds();
            if (list == null || list.Count < 5)
            {
                Article art1 = new Article();
                art1.Author = "John Doe";
                art1.Headline = "A Fantastic Engaging Headline Goes Here!";
                art1.Picture = "~/Content/assets/wave.jpg";
                art1.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

                Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.
                
                Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.
                
                Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.
                
                Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art1.AuthorPicture = "/Content/assets/mike.jpg";
                art1.Date = DateTime.Today;
                art1.isAdvertisement = false;
                art1.Id = Guid.NewGuid();
                list.Add(art1);
          
                Article art2 = new Article();
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
                art2.Id = Guid.NewGuid();
                list.Add(art2);
           
                Article art3 = new Article();
                art3.Author = "Janet Reno";
                art3.Headline = "Post Title";
                art3.Picture = "/Content/assets/surfboarddude.jpg";
                art3.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

                Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.
                
                Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.
                
                Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.
                
                Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art3.AuthorPicture = "/Content/assets/mike.jpg";
                art3.Date = DateTime.Today;
                art3.isAdvertisement = false;
                art3.Id = Guid.NewGuid();
                list.Add(art3);
          
                Article art4 = new Article();
                art4.Author = "Janet Reno";
                art4.Headline = "Another Post Post Title";
                art4.Picture = "/Content/assets/surfboarddude.jpg";
                art4.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

                Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.
                
                Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.
                
                Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.
                
                Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art4.AuthorPicture = "/Content/assets/mike.jpg";
                art4.Date = DateTime.Today;
                art4.isAdvertisement = false;
                art4.Id = Guid.NewGuid();
                list.Add(art4);
           
                Article art5 = new Article();
                art5.Author = "Janet Reno";
                art5.Headline = "And yet another Post Title";
                art5.Picture = "/Content/assets/surfboarddude.jpg";
                art5.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

                Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.
                
                Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.
                
                Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.
                
                Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                art5.AuthorPicture = "/Content/assets/mike.jpg";
                art5.Date = DateTime.Today;
                art5.isAdvertisement = false;
                art5.Id = Guid.NewGuid();
            }
            if ( adList == null || adList.Count < 1)
            {
                Article ad1 = new Article();
                ad1.Author = "Janet Reno";
                ad1.Headline = "Advert Title";
                ad1.Picture = "/Content/assets/surfboarddude.jpg";
                ad1.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dictum, enim vel gravida tempus, magna tellus elementum neque, nec tempus tellus augue accumsan libero. Praesent aliquam, orci eu tristique rutrum, orci ipsum pulvinar nunc, id cursus odio nunc nec turpis. Suspendisse id tincidunt libero, dictum luctus tellus. Aliquam condimentum erat augue, et facilisis sem euismod id. Quisque eros risus, semper et semper nec, sodales eu tellus. Nunc sodales quam eget tortor fermentum, at placerat ante ornare. Quisque ac dui nisi. In hac habitasse platea dictumst. Aliquam ex odio, lacinia quis purus a, blandit eleifend purus. Sed a sem congue, convallis nisl in, sollicitudin dui. Sed nec elit sit amet lorem suscipit congue. Integer iaculis tortor sit amet arcu dapibus, quis cursus tellus egestas. Nunc ac orci tortor. Proin at ipsum accumsan, egestas massa vel, venenatis metus. Vestibulum ac porta velit, bibendum vestibulum ligula. Aliquam pretium venenatis nunc, non iaculis est cursus nec.

                Vestibulum rutrum molestie scelerisque. Pellentesque massa ex, iaculis sit amet tempor vitae, pulvinar interdum eros.Vestibulum vestibulum nisl euismod feugiat vulputate. Donec maximus lacinia rutrum. Ut finibus aliquam tortor, ut condimentum massa volutpat rutrum. Aenean ut nisl a urna imperdiet tincidunt.Mauris quis dictum quam.
                
                Curabitur dictum placerat massa, eu facilisis velit pharetra ut. Nulla non maximus mauris, vel ultricies arcu. Mauris at pretium arcu. In euismod lacus id orci efficitur scelerisque.Integer sapien libero, rhoncus vel leo nec, condimentum viverra libero. Praesent viverra quam nisi, at accumsan velit posuere vitae. Integer vel fringilla elit. Proin vel est condimentum, sodales magna vel, venenatis dolor.Aenean quis iaculis tortor. Duis consequat, ligula nec viverra tristique, urna urna porta felis, sed dictum risus risus cursus lectus.Pellentesque sagittis eget nibh et venenatis. Vivamus tempus hendrerit augue. Aliquam arcu leo, dignissim non urna non, blandit fringilla nulla. Nam vehicula tristique nulla, quis scelerisque leo placerat eu. Morbi non rhoncus sem. Donec accumsan metus felis, quis commodo ipsum facilisis ac.
                
                Sed maximus eu purus et gravida. Etiam eu risus vel massa vulputate vulputate.Phasellus mattis eleifend quam, ac varius metus vulputate faucibus. Donec laoreet sem sit amet orci imperdiet fringilla. Donec convallis nunc diam, sit amet blandit felis vestibulum non.Nunc at sapien ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam eget erat consectetur, consectetur turpis vel, eleifend eros.Fusce in maximus ligula, vitae blandit mauris.
                
                Donec viverra finibus justo, semper dignissim magna vestibulum et. Morbi auctor aliquam scelerisque. Fusce ac quam turpis. Praesent at vestibulum metus. Donec vel commodo dolor. Morbi malesuada nulla quis dictum elementum. In vestibulum, nulla fermentum efficitur pretium, orci dolor cursus enim, varius venenatis neque urna viverra est.Quisque tincidunt tristique ex, ut finibus magna accumsan sed. Sed sed risus malesuada, aliquet libero ut, pellentesque est.Pellentesque aliquam augue tellus, luctus iaculis tortor mattis eu. Nullam gravida sollicitudin faucibus. Donec gravida sodales nunc eget viverra. Praesent sit amet blandit libero.Proin at massa in quam ultricies tincidunt eu ac magna. Suspendisse potenti.";
                ad1.AuthorPicture = "/Content/assets/mike.jpg";
                ad1.Date = DateTime.Today;
                ad1.isAdvertisement = true;
                ad1.Id = Guid.NewGuid();
                adList.Add(ad1);
            }
            StoreArticleList(list);
            StoreAds(adList);
                

        }
        
    }
}
