using System;
using System.Collections.Generic;
using System.Text;

namespace NarojayBlog.ManagerEntity
{
    public class GuestBookEntity
    {
        public string Id { set; get; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
