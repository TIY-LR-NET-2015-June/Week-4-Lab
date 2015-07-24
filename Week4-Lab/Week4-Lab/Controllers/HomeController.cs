using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week4_Lab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogPost()
        {

            return View();
        }

        public ActionResult NewPost()
        {

            return View();
        }
    }
}