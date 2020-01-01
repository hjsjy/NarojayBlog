using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Webapi.Helper;
using Newtonsoft.Json;

namespace NarojayBlog.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private readonly NarojayContext _context;

        private const string ClientId = "group_id@@@0001";
        public ValuesController(IMapper mapper,NarojayContext context) : base(mapper)
        {
            _context = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
               var articles = _context.Articles.Where(x => (id == null || x.Id == id) 
                                                           && x.CreateTime <= DateTime.Now.AddMonths(-6)).ToList();
            return  Ok(articles);
        }                   
        // POST api/values
        [HttpPost]
        public async Task Post(string value)
        {
        var options = new MqttClientOptionsBuilder()
            .WithClientId(ClientId)
            .WithTcpServer("106.14.142.74", 1883)
            .WithCredentials("admin", "123456")
            .WithCleanSession()
            .Build();
        MqttClient mqttclient = new MqttFactory().CreateMqttClient() as MqttClient;
            if (null == mqttclient)
        {
            throw new Exception("mqttclient为空");
        }
        await mqttclient.ConnectAsync(options);
        var sendTopic = $"topic/narojay";
        var sendMsg = JsonConvert.SerializeObject(new ChannelTokenModel
        {
            Token = value,
            ChannelId = value
        });
        var msg = new MqttApplicationMessageBuilder().WithTopic(sendTopic).WithPayload(sendMsg)
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false)
            .Build();
        for (int i = 0; i < 1000; i++)
        {
            mqttclient.PublishAsync(msg);
        }
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