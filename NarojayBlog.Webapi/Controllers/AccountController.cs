using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace NarojayBlog.Webapi.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IMapper mapper) : base(mapper)
        {
        }
    }
}
