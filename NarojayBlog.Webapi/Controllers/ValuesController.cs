using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Markdig.Syntax;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.IManager;
using NarojayBlog.Manager;
using NarojayBlog.ViewModel;
using NarojayBlog.Webapi.Filters;

namespace NarojayBlog.Webapi.Controllers
{
  
    public class ValuesController : BaseController
    {
        private readonly IArticleManager _articleManager;

        public ValuesController(IArticleManager articleManager , IMapper mapper) : base(mapper)
        {
            _articleManager = articleManager;
        }
        // GET api/values
        [HttpPost("values")]
        public string Get(ArticleAddViewModel view)
        {
            try
            {
              return   _articleManager.TestException(view.Author);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "asdas";
            }

        }
    }
}
