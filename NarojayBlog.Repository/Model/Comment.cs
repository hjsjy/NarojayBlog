using System;

namespace NarojayBlog.DatabaseRepository.Model
{
    public class Comment : BaseModel
    {
        public string Name { get; set; }

        public string Content { get; set;  }

        public DateTime CreateTime { get; set; }

        public string ArticleId { get; set; }
    }
}
