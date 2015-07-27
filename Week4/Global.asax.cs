using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Week4.Models;



namespace Week4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            if (HttpContext.Current.Application["SiteUsers"] == null)
            {
                HttpContext.Current.Application["SiteUsers"] = SiteUser.GetUsersFromCsv();
            }

            HttpContext.Current.Application["LipsumsFilename"] = @"C:\Projects\TIY.NET\Week4Lab\lipsum.txt";
            if (HttpContext.Current.Application["Lipsums"] == null)
            {
                HttpContext.Current.Application["Lipsums"] = Post.GetLinesFromCsv((string)HttpContext.Current.Application["LipsumsFilename"]);
            }

            HttpContext.Current.Application["TitlesFilename"] = @"C:\Projects\TIY.NET\Week4Lab\titles.txt";
            if (HttpContext.Current.Application["Titles"] == null)
            {
                HttpContext.Current.Application["Titles"] = Post.GetLinesFromCsv((string)HttpContext.Current.Application["TitlesFilename"]);
            }

            if (HttpContext.Current.Application["Posts"] == null)
            {
                HttpContext.Current.Application["Posts"] = Post.GenerateRandomPosts(10);
            }
            if (HttpContext.Current.Application["Ads"] == null)
            {
                HttpContext.Current.Application["Ads"] = Ad.GenerateAds(8);
            }
        }
    }
}
