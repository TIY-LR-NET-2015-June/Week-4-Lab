using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4_Lab.Models
{
    public class Post
    {
        [Required]
        [MaxLength(100)]
        [Display(Name ="Post Title")]
        public string Title { get; set; }

        [DataType (DataType.MultilineText)]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        public string Author { get; set; }

        public int ID { get; set; }
    }
}