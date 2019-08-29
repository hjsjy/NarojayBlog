using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.Repository
{
    public class GuestBookRepository : BaseRepository<GuestBook>
    {
        public GuestBookRepository(NarojayContext context) : base(context, context.GuestBooks)
        {
        }
    }
}
