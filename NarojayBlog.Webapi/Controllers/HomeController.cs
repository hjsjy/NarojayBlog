using AutoMapper;

namespace NarojayBlog.Webapi.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper) : base(mapper)
        {
            int c = 3;
        }
    }
}
