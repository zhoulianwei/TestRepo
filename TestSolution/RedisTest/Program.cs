using StackExchange.Redis;
using System;

namespace RedisTest
{
    internal class Program
    {
        private int id { get; set; }

        static void Main(string[] args)
        {
            var redisAddress = "localhost";
            var muxer = ConnectionMultiplexer.Connect(redisAddress);
            var redisDb = muxer.GetDatabase();
            redisDb.StringSet("key1", "value1");
            redisDb.StringSet("key2", "value2");
            var isConnected = redisDb.IsConnected("123ABC");
            Console.ReadKey();
        }
    }



}
