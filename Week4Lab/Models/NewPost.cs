using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4Lab.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Text { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
    }
}