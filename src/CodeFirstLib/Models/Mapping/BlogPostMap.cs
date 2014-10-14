using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirstLib.Models.Mapping
{
    public class BlogPostMap : EntityTypeConfiguration<BlogPost>
    {
        public BlogPostMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Code, t.CategoryCode });

            // Properties
            // Table & Column Mappings
            this.ToTable("BlogPosts");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode");



            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.BlogPosts)
                .HasForeignKey(d => d.CategoryCode);

        }
    }
}
