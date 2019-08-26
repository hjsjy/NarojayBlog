using System;
using System.Collections.Generic;
using System.Text;
using NarojayBlog.ManagerEntity;

namespace NarojayBlog.IManager
{
    public interface ICatalogManager
    {
        bool AddCatalog(CatalogEntity entity);

        IEnumerable<CatalogEntity> GetCatalogs();
    }
}
