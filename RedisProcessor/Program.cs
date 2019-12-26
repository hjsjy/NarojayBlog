using System;
using System.Collections.Concurrent;
using NarojayBlog.Core;
using StackExchange.Redis;

namespace RedisProcessor
{
    public class Program
    {
        public static  ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        private void Fuck(RedisChannel channel, RedisValue message)
        {
        
            queue.Enqueue((int)message);
           
        }

        public void Start()
        {
            RedisHelper.Instance.Initialize();
            RedisHelper.Instance.Subscriber.Subscribe("test", Fuck);
        }
        static void Main(string[] args)
        {
          new Program().Start();
          Console.WriteLine(" Press [enter] to exit.");
          Console.ReadLine();
        }
    }
}
