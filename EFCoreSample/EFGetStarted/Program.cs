using System;
using System.Linq;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog() {Url = "http://blogs.msdn.com/dotnet"});
                db.SaveChanges();

                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs.OrderBy(b => b.BlogId).First();

                Console.WriteLine("Updating the blog and adding a post");

                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post()
                {
                    Title = "Hello world",
                    Content = "I wrote an app using EF Core!"
                });

                db.SaveChanges();

                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();

            }


        }
    }
}
