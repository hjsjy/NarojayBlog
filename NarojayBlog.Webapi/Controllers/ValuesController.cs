using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NarojayBlog.Webapi.Controllers;

namespace Hippo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {


        public ValuesController(IMapper mapper): base(mapper)
        {
       
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "asdasd";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return 0;
        }

        // POST api/values
        [HttpPost]
        public int Post(string value)
        {
            return 0;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}