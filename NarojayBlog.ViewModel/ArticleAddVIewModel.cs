using System;
using System.Collections.Generic;
using System.Text;

namespace NarojayBlog.ViewModel
{
    public class ArticleAddViewModel
    {
        public DateTime CreateTime { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int ReadingAmount { get; set; }

        public int CommentAmount { get; set; }

        public int PraiseAmount { set; get; }

        public string CatalogId { get; set; }

    }
}
