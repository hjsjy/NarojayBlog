using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Repository.IRepository;

namespace NarojayBlog.Repository.Repository
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : BaseModel

    {
        protected readonly NarojayContext DbContext;
        protected readonly DbSet<TModel> DbSet;

        protected BaseRepository(NarojayContext dbContext,DbSet<TModel> dbSet)
        {
            DbContext = dbContext;
            DbSet = dbSet;
        }
        public bool Insert(TModel model)
        {
            DbContext.Add(model);
            var result = DbContext.SaveChanges() > 0;
            return result;
        }

        public bool Delete(TModel model)
        {
            DbContext.Remove(model);
            var result = DbContext.SaveChanges() > 0;
            return result;
        }

        public bool Update(TModel model)
        {
            DbContext.Update(model);
            var result = DbContext.SaveChanges() > 0;
            return result;
        }

        public bool DeleteBy(Expression<Func<TModel, bool>> predicate)
        {
            DbSet.RemoveRange(DbSet.Where(predicate));
            var result = DbContext.SaveChanges() > 0;
            return result;

        }
    }
}
