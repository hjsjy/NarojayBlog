using System;

namespace NarojayBlog.ManagerEntity
{
    public class ArticleEntity
    {
        public string Id { get; set; }

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
