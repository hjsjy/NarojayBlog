using System.Collections.Generic;

namespace NarojayBlog.ViewModel
{
    public class PageModel<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Values { get; set; }
        public decimal PageSize { get; set; }
    }
}
