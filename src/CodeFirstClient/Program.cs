using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFirstLib;
using System.Data.Entity;
using System.Collections.ObjectModel;
using RefactorThis.GraphDiff;
using CodeFirstLib.Models;

namespace CodeFirstClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<BlogDbContext>(new BlogContextInitializer());

            var postCode = Guid.NewGuid().ToString("D");
            var catCode = Guid.NewGuid().ToString("D");

            var cat = new Category { Code = catCode, Name = "ASP.NET" };

            var post = new BlogPost { Code = postCode, Title = "Title1", Content = "Hello World!", PublishDate = new DateTime(2011, 1, 1) };
            cat.BlogPosts = new Collection<BlogPost>();
            cat.BlogPosts.Add(post);
                

            using (var db = new BlogDbContext())
            {
                db.Categories.Add(cat);

                Console.WriteLine(db.Database.Connection.ConnectionString);
                
                int i = db.SaveChanges();
                Console.WriteLine("{0} records added...", i);

            }

            using (var db = new BlogDbContext())
            {
                cat = db.Categories.Include("BlogPosts").Where(q => q.Code == catCode).FirstOrDefault();
            }

            cat.BlogPosts.FirstOrDefault().Title = "Title  12111";

            postCode = Guid.NewGuid().ToString("D");
            post = new BlogPost { Code = postCode, Title = "Title2", Content = "Hello World 2!", PublishDate = new DateTime(2011, 1, 1) };
          
            cat.BlogPosts.Add(post);

            using (var db = new BlogDbContext())
            {
                cat = db.UpdateGraph<Category>(cat, o => o.OwnedCollection(e => e.BlogPosts));
                int i = db.SaveChanges();
                Console.WriteLine("{0} records ...", i);
            }

            Console.ReadLine();
        }
    }
}
