using System.Collections.Generic;
using NarojayBlog.Manager.Entiy;

namespace NarojayBlog.Manager.IManager
{
    public interface IGuestBookManager
    {
        IEnumerable<GuestBookEntity> GetAllGuestBook();
    }
}
