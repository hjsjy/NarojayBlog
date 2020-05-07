using AutoMapper;

namespace NarojayBlog.Webapi.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMapper mapper) : base(mapper)
        {
            int d = 1;
            int f = 5;
        }
    }
}
