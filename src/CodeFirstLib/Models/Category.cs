using System;
using System.Collections.Generic;

namespace CodeFirstLib.Models
{
    public partial class Category
    {
        public Category()
        {
            this.BlogPosts = new List<BlogPost>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
