using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NarojayBlog.DatabaseRepository.DbContext;

namespace NarojayBlog.DatabaseRepository
{
    public interface IUnitOfWork : IDisposable
    {
        NarojayContext Context { get; }
        void Commit();
    }
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
