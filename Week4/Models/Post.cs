using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Week4;


namespace Week4.Models
{
    public class Post
    {
        public static int PostCount
        {
            get
            {
                if (HttpContext.Current.Application["Posts"] == null) return 0;
                var x = (List<Post>)HttpContext.Current.Application["Posts"];
                return x.Count;
            }
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeSubmitted { get; set; }
        public SiteUser Author { get; set; }
        public string Text { get; set; }
        public string ImgFilename { get; set; }
        public int Likes { get; set; }

        public string PreviewText
        {
            get { return this.Text.Substring(0, 255); }
        }
        public string TimeStamp
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(this.DateTimeSubmitted.ToShortDateString() + "\t");
                sb.AppendLine(this.DateTimeSubmitted.ToShortTimeString());
                return sb.ToString();
            }
        }

        public static List<string> GetLinesFromCsv(string filename)
        {
            var reader = System.IO.File.OpenText(filename);
            List<string> results = new List<string>();
            while (!reader.EndOfStream)
                results.Add(reader.ReadLine());
            return results;
        }
        public static string GetRandomLipsum(List<string> st)
        {
            return st.OrderBy(x => Guid.NewGuid()).First();
        }


        public static List<Post> GenerateRandomPosts(int count)
        {
            List<Post> result = new List<Post>();

            for (int i = 0; i < count; i++)
            {
                List<SiteUser> users = (List<SiteUser>)HttpContext.Current.Application["SiteUsers"];
                var author = users.OrderBy(x => Guid.NewGuid()).First();
                var description = GetRandomLipsum((List<string>)HttpContext.Current.Application["Titles"]);
                var text = GetRandomLipsum((List<string>)HttpContext.Current.Application["Lipsums"]);
                result.Add(author.TryMakePost(description, text));
            }
            return result;
        }

       public static List<Post> GetRandomPosts(int count = 4)
        {
            var posts = new List<Post>();
            for (int i = 0; i < count; i++)
            {
                posts.Add(GetRandomPost());
            }
            return posts;
        }

        public static Post GetRandomPost()
        {
            List<Post> posts = (List<Post>)HttpContext.Current.Application["Posts"];
            return posts.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}