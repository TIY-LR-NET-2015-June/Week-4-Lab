using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.ApplicationServices;
using Week4.Models;

namespace Week4.Controllers
{
    public class SiteUserController : Controller
    {
       
      
        public ActionResult Index()
        {
            return View(HttpContext.Application["SiteUsers"]);
        }

        public ActionResult Login()
        {
            return View();
        }

        //Login - Post Login attempt info (POST)
        [HttpPost]
        public ActionResult Login(string userId, string redirectUrl, string password = "password")
        {
            List<SiteUser> usrs = (List<SiteUser>)HttpContext.Application["SiteUsers"];
            var usr = usrs.First(x => x.UserId == userId);
            if (usr.Password == "password") Session["CurrentUser"] = usr;
            else return View("Denied");
            return RedirectToAction("Index", "Post");
        }

        // GET: DENIED
        [HttpGet]
        public ActionResult Denied()
        {
            return View("Denied");
        }
        // GET: SiteUser/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: SiteUser/Register
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: SiteUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: SiteUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SiteUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SiteUser usr)
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

        // GET: SiteUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SiteUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
