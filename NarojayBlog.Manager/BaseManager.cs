using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Repository.IRepository;

namespace NarojayBlog.Manager
{
    public abstract class BaseManager<TModel, TEntity, TRepository>
        where TModel : BaseModel
        where TRepository : IRepository<TModel>
    {
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;

        protected BaseManager(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntity>>(Repository.GetAll());
        }

        public TEntity GetById(string id)
        {
            return Mapper.Map<TEntity>(Repository.GetById(id));
        }

        public bool InsertArticle(TEntity entity)
        {
            return Repository.Insert(Mapper.Map<TModel>(entity));
        }
    }
}
