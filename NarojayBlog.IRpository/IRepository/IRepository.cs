using System;
using System.Linq.Expressions;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.Repository.IRepository
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
        bool Insert(TModel model);
        bool Delete(TModel model);
        bool Update(TModel model);
        bool DeleteBy(Expression<Func<TModel,bool>> predicate);

    }
}
