using System;

namespace NarojayBlog.Manager.Entiy
{
    public class GuestBookEntity
    {
        public string Id { set; get; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
