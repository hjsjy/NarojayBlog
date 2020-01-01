using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Server;

namespace NarojayBlog.Webapi.Controllers
{
    public class CommandController : BaseController
    {
        public CommandController(IMapper mapper) : base(mapper)
        {


        }
    }
}
