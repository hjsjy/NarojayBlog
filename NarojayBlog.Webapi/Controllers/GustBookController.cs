using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.Manager.Manager;

namespace NarojayBlog.Webapi.Controllers
{
    public class GustBookController : BaseController
    {
        private readonly GuestBookManager _guestBookManager;

        public GustBookController(IMapper mapper, GuestBookManager guestBookManager) : base(mapper)
        {
            _guestBookManager = guestBookManager;
        }

        [HttpGet("GuestBook")]
        public IActionResult GetGuestBooks()
        {
            var result = _guestBookManager.GetAllGuestBook();
            return Ok(result);
        }
    }
}
