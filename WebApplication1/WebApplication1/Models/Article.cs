using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Article
    {
        public string Author { get; set; }
        public string AuthorPicture { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public string Info { get; set; }
        public int Rating { get; set; }
    }
}