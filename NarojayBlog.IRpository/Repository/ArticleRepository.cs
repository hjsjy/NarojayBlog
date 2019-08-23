using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        protected ArticleRepository(NarojayContext context) : base(context, context.Articles)
        {
        }

    }
}
