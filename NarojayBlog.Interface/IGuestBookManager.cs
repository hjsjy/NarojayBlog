using System;
using System.Collections.Generic;
using System.Text;
using NarojayBlog.ManagerEntity;

namespace NarojayBlog.IManager
{
    public interface IGuestBookManager
    {
        IEnumerable<GuestBookEntity> GetAllGuestBook();
    }
}
