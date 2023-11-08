using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace publisher
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", false, true).
                Build();


            // Redis start
            var redis = ConnectionMultiplexer.Connect(configuration["RedisConnectionString"]);
            var pubsub = redis.GetSubscriber();

            // publish
            var rm = new RedisMessage()
            {
                Name = "test",
                Message = "message"
            };
            var notificationChannel = configuration["RedisNotificationChannel"];
            pubsub.Publish(notificationChannel,JsonConvert.SerializeObject(rm), CommandFlags.FireAndForget);

            Console.WriteLine($"publishing to {notificationChannel}");
        }
    }

    public class RedisMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}