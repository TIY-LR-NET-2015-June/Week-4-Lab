using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Week4;

namespace Week4.Models
{
    public class SiteUser
    {

        public static int UserCount { get; set; }

        public int ID;
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgFilename { get; set; }
        public string Password { get; set; }

        public string FullName => FirstName + " " + LastName;
        public int PostCount { get; set; }

        public SiteUser(string userId, string firstName, string lastName, string imgFilename)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ImgFilename = "/images/" + imgFilename;
            ID = UserCount + 1;
            Password = "password";
            UserCount++;

        }

        public static List<SiteUser> GetUsersFromCsv(string filename = "./siteusers.csv")
        {
            filename = HttpContext.Current.Server.MapPath("./siteusers.csv");

            List<SiteUser> users = new List<SiteUser>();
            var reader = System.IO.File.OpenText(filename);
            while (!reader.EndOfStream)
            {
                var fields = reader.ReadLine().Split(',');
                users.Add(new SiteUser(fields[0], fields[1], fields[2], fields[3]));
            }
            return users;
        }

        public Post TryMakePost(string description, string text)
        {
            Post newPost = new Post
            {
                Author = this,
                DateTimeSubmitted = DateTime.Now,
                Description = description,
                Text = text,
                Id = Guid.NewGuid()
            };
            return newPost;
        }
    }
}