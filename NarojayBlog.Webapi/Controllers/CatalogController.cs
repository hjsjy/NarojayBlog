using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace NarojayBlog.Webapi.Controllers
{
    public class CatalogController : BaseController
    {
        public CatalogController(IMapper mapper) : base(mapper)
        {
        }
    }
}
