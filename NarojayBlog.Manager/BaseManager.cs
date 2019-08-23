using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Repository.IRepository;

namespace NarojayBlog.Manager
{
    public abstract class BaseManager<TModel, TEntity, TRepository>
        where TModel : BaseModel
        where TRepository : IRepository<TModel>
    {
        private readonly TRepository Repository;
        private readonly IMapper Mapper;

        protected BaseManager(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
    }
}
