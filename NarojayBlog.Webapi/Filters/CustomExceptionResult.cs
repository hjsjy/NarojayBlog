using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NarojayBlog.Webapi.Filters
{
    public class CustomExceptionResult : ObjectResult
    {
        public CustomExceptionResult(int? code, Exception exception)
            : base(new CustomExceptionResultModel(code, exception))
        {
            StatusCode = code;
        }
    }
}
