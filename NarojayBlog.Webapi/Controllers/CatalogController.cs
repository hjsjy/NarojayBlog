using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.IManager;
using NarojayBlog.ManagerEntity;
using NarojayBlog.ViewModel;

namespace NarojayBlog.Webapi.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(IMapper mapper,ICatalogManager catalogManager) : base(mapper)
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
            try
            {
                var catalogEntities = _catalogManager.GetCatalogs();
                return Ok(catalogEntities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
    }
}
