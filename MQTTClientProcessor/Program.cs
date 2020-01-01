using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MQTTClientProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            HandleMQTTMessage();
        }

        public static async Task HandleMQTTMessage()
        {
            var options = new MqttClientOptionsBuilder()
                .WithClientId("narojay-recever")
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
            await mqttclient.SubscribeAsync(new TopicFilterBuilder().WithTopic("topic/narojay").Build());
            mqttclient.UseApplicationMessageReceivedHandler(e => { Console.WriteLine(Encoding.UTF8.GetString(e.ApplicationMessage.Payload)); });
            Console.ReadKey();
        }
    }
}
