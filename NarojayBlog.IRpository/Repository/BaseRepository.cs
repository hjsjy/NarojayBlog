using System;
using System.Collections.Generic;
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

        protected BaseRepository(NarojayContext context,DbSet<TModel> dbSet)
        {
            DbContext = context;
            DbSet = dbSet;
        }
        public bool Insert(TModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            DbContext.Add(model);
            var result = DbContext.SaveChanges() > 0;
            return result;
        }

        public IEnumerable<TModel> GetBy(Expression<Func<TModel,bool>> predicate)
        {
            return DbSet.Where(predicate);
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

        public TModel GetById(string id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TModel> GetPage(int page,int size)
        {
            return DbSet.Skip((page-1)*size).Take(size).ToList();
        }
    }
}
