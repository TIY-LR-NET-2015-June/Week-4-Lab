using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Week4.Models
{
    public class Post
    {
        public static int PostCount
        {
            get
            {
                if (HttpContext.Current.Application["Posts"] == null) return 0;
                var x = (List<Post>) HttpContext.Current.Application["Posts"];
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
            get
            {
                if (Text.Length < 128) return Text;
                return Text.Substring(0, 128);
            }
        }

        public string TimeStamp
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine(DateTimeSubmitted.ToShortDateString() + "\t");
                sb.AppendLine(DateTimeSubmitted.ToShortTimeString());
                return sb.ToString();
            }
        }

        public static List<string> GetLinesFromCsv(string filename)
        {
            var reader = File.OpenText(filename);
            var results = new List<string>();
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
            var result = new List<Post>();

            for (var i = 0; i < count; i++)
            {
                var users = (List<SiteUser>) HttpContext.Current.Application["SiteUsers"];
                var author = users.OrderBy(x => Guid.NewGuid()).First();
                var description = GetRandomLipsum((List<string>) HttpContext.Current.Application["Titles"]);
                var text = GetRandomLipsum((List<string>) HttpContext.Current.Application["Lipsums"]);

                result.Add(author.TryMakePost(description, text));
            }
            return result;
        }

        public static List<Post> GetRandomPosts(int count = 4)
        {
            var posts = new List<Post>();
            for (var i = 0; i < count; i++)
            {
                posts.Add(GetRandomPost());
            }
            return posts;
        }

        public static Post GetRandomPost()
        {
            var posts = (List<Post>) HttpContext.Current.Application["Posts"];
            return posts.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}