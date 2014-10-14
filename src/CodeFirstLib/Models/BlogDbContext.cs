using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodeFirstLib.Models.Mapping;
using System;

namespace CodeFirstLib.Models
{
    public partial class BlogDbContext : DbContext
    {
        //static BlogDbContext()
        //{
        //    Database.SetInitializer<BlogDbContext>(null);
        //}

        public BlogDbContext()
            : base("Name=BlogDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogPostMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }

    public class BlogContextInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
           

        }
    }
}
