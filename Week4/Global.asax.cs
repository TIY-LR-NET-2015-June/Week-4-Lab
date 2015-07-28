using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Week4.Models;

namespace Week4
{
    public class MvcApplication : HttpApplication
    {
        public static List<SiteUser> SiteUsers
        {
            get { return (List<SiteUser>)HttpContext.Current.Application["SiteUsers"]; }
            set
            {
                HttpContext.Current.Application["SiteUsers"] = value;
              }
        }
        public static List<Post> Posts
        {
            get { return (List<Post>)HttpContext.Current.Application["Posts"]; }
            set
            {
                HttpContext.Current.Application["Posts"] = value;
            }
        }

        //public static List<SiteUser> SiteUsers = (List<SiteUser>)HttpContext.Current.Application["SiteUsers"];
       
        protected void Application_Start()
        {
            //Designer added
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //If application is newly run, set Application variables
            HttpContext.Current.Application["SiteUserFilename"] = HttpContext.Current.Server.MapPath("/siteusers.csv");
            if (HttpContext.Current.Application["SiteUsers"] == null)
                HttpContext.Current.Application["SiteUsers"] =
                    SiteUser.GetUsersFromCsv((string)HttpContext.Current.Application["SiteUsersFilename"]);

            //These 3 are for generating random posts.
            HttpContext.Current.Application["LipsumsFilename"] = HttpContext.Current.Server.MapPath("/lipsum.txt");
            if (HttpContext.Current.Application["Lipsums"] == null)
                HttpContext.Current.Application["Lipsums"] =
                    Post.GetLinesFromCsv((string)HttpContext.Current.Application["LipsumsFilename"]);

            HttpContext.Current.Application["TitlesFilename"] = HttpContext.Current.Server.MapPath("titles.txt");
            if (HttpContext.Current.Application["Titles"] == null)
                HttpContext.Current.Application["Titles"] =
                    Post.GetLinesFromCsv((string)HttpContext.Current.Application["TitlesFilename"]);

            if (HttpContext.Current.Application["Posts"] == null)
                HttpContext.Current.Application["Posts"] = Post.GenerateRandomPosts(10);
        }
    }
}