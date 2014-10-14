using System;
using System.Collections.Generic;

namespace CodeFirstLib.Models
{
    public partial class BlogPost
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string CategoryCode { get; set; }
        public Category Category { get; set; }
    }
}
