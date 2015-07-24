using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfAndPaddle.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeSubmitted { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
        public string ImgFilename { get; set; }
        public int Likes { get; set; }



    }
}