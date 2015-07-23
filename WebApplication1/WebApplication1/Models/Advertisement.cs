using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Advertisement
    {
        public Advertiser Advertiser { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
    }
}