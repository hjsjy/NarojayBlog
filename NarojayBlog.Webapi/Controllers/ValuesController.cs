using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.ViewModel;
using NarojayBlog.Webapi.Filters;

namespace NarojayBlog.Webapi.Controllers
{
  
    public class ValuesController : BaseController
    {
        // GET api/values
        [HttpPost("values")]
        public ActionResult Get(ArticleAddViewModel view)
        {
            List<string> list = null;
            return Ok(list);
        }

        public ValuesController(IMapper mapper) : base(mapper)
        {
        }
    }
}
