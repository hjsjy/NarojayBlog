using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.Repository
{
    public class CatalogRepository :BaseRepository<Catalog>
    {
        protected CatalogRepository(NarojayContext context) : base(context, context.Catalogs)
        {
        }
    }
}
