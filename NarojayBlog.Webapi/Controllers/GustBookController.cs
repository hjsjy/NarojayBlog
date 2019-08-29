using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarojayBlog.Manager;

namespace NarojayBlog.Webapi.Controllers
{
    public class GustBookController :BaseController
    {
        private readonly GuestBookManager _guestBookManager;

        public GustBookController(IMapper mapper, GuestBookManager guestBookManager) : base(mapper)
        {
            _guestBookManager = guestBookManager;
        }

        [HttpGet("GuestBook")]
        public IActionResult GetGuestBooks()
        {
            try
            {
                var result = _guestBookManager.GetAllGuestBook();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
