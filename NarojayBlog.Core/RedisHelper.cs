using StackExchange.Redis;
using System;

namespace NarojayBlog.Core
{
    public class RedisHelper : IDisposable
    {
        private readonly object _locker = new object();
        private ConfigurationOptions _configurationOptions;
        public RedisHelper() { }
        public static RedisHelper Instance { get; } = new RedisHelper();

        public void Initialize()
        {
            _configurationOptions = ConfigurationOptions.Parse("localhost:6379,password=,connectTimeout=2000");
            GetRedisConnection();
        }
        public IDatabase GetDb()
        {
            return GetRedisConnection().GetDatabase();
        }
        private IConnectionMultiplexer _redisConnection;
        public ISubscriber Subscriber { get; private set; }
        private IConnectionMultiplexer GetRedisConnection()
        {
            if (_redisConnection == null)
            {
                lock (_locker)
                {
                    if (_redisConnection == null)
                    {
                        _redisConnection = ConnectionMultiplexer.Connect(_configurationOptions);
                        Subscriber = _redisConnection.GetSubscriber();
                    }
                }
            }
            return _redisConnection;
        }

        public void Dispose()
        {
            _redisConnection?.Dispose();
        }

    }
}
