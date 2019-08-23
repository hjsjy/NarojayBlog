using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NarojayBlog.Webapi.Controllers
{

    public class ValuesController : BaseController
    {
        // GET api/values
        [HttpGet("values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] {"value1", "value2"};
        }
    }
}
