using System.Collections.Generic;
using NarojayBlog.Manager.Entiy;

namespace NarojayBlog.Manager.IManager
{
    public interface ICatalogManager
    {
        bool AddCatalog(CatalogEntity entity);

        IEnumerable<CatalogEntity> GetCatalogs();
    }
}
