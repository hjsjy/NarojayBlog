using System;
using System.Collections.Generic;
using System.Text;

namespace NarojayBlog.DatabaseRepository.Model
{
    public class Catalog :BaseModel
    {
        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
