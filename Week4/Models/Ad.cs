using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Week4.Models
{
    public class Ad
    {
        public static int AdCount;
        public int ID { get; set; }
        public string ImageFilename { get; set; }

        public Ad(string imageFilename)
        {
            ImageFilename = imageFilename;
            ID = AdCount;
            AdCount++;
        }

        public static List<Ad> GenerateAds(int count = 3)
        {
            List<Ad> Ads = new List<Ad>();
            for (int i = 0; i < count; i++)
                Ads.Add(new Ad($"./images/ads/ad{i}.png"));

            return Ads;
        }

        public static string RenderHTML(List<Ad> ads)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Ad ad in (List<Ad>)HttpContext.Current.Application["Ads"])
            {
                //< img src = "smiley.gif" alt = "Smiley face" height = "42" width = "42" >
           //     var tmp = string.Format("<img src =\"" + ad.ImageFilename + "\" >");
              //  sb.AppendFormat("<img src=\"" + ad.ImageFilename + "\" " + " alt=\"ad\">");
            }
            return sb.ToString();
        }
    }
}