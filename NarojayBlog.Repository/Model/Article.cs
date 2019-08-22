using System;

namespace NarojayBlog.DatabaseRepository.Model
{
    public class Article : BaseModel
    {
        public DateTime CreateTime { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int ReadingAmount { get; set; }

        public int CommentAmount { get; set; }

        public int PraiseAmount { set; get; }

        public string CatalogId { get; set; }

        public Catalog Catalog { get; set; }
    }
}
