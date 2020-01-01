using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.Manager.Entiy;
using NarojayBlog.Manager.IManager;
using NarojayBlog.ViewModel;

namespace NarojayBlog.Webapi.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(IMapper mapper, ICatalogManager catalogManager) : base(mapper)
        {
            _catalogManager = catalogManager;
        }
        [HttpPost]
        public IActionResult AddCatalog(CatalogAddViewModel catalogAddViewModel)
        {
            var result = _catalogManager.AddCatalog(Mapper.Map<CatalogEntity>(catalogAddViewModel));
            if (!result)
            {
                return BadRequest("插入失败");
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCatalogs()
        {
            var catalogEntities = _catalogManager.GetCatalogs();
            return Ok(catalogEntities);
        }

    }
}
