using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Article
    {   
        [Key]
        public int Id { get; set; }

        [DisplayName("Enter Your Name")]
        [Required(ErrorMessage = "please let us now who you are")]
        public string Author { get; set; }

        [DisplayName("Enter a URL for your picture")]
        public string AuthorPicture { get; set; }

        [DisplayName("Enter a title for you post")]
        [Required]
        public string Headline { get; set; }

        [DisplayName("Enter your post here")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [DisplayName("Add a picture to your post to make it interesting")]
        public string Picture { get; set; }

        [DisplayName("Is this an advertisement for a product or service?")]
        public bool isAdvertisement { get; set; }

        [DisplayName("Date of your article")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: yyyy MMM dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}