using System.Collections.Generic;
using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Manager.Entiy;
using NarojayBlog.Manager.IManager;
using NarojayBlog.Repository.Repository;

namespace NarojayBlog.Manager.Manager
{
    public class CatalogManager : BaseManager<Catalog,CatalogEntity,CatalogRepository>, ICatalogManager
    {
        public CatalogManager(CatalogRepository catalogRepository, IMapper mapper) : base(catalogRepository, mapper)
        {
        }

        public bool AddCatalog(CatalogEntity entity)
        {
            return Repository.Insert(Mapper.Map<Catalog>(entity));
        }

        public IEnumerable<CatalogEntity> GetCatalogs()
        {
            return Mapper.Map<IEnumerable<CatalogEntity>>(Repository.GetAll());

        }
    }
}
