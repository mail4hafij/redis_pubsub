using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace subscriber
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

            // Create different handlers depending on different channels
            var notificationChannel = configuration["RedisNotificationChannel"];
            pubsub.Subscribe(notificationChannel, (channel, message) => ConsumeHandler(message));
            Console.WriteLine($"Listening to {notificationChannel}");

            Console.ReadLine();
        }

        private static void ConsumeHandler(string message)
        {
            RedisMessage rm = JsonConvert.DeserializeObject<RedisMessage>(message);
            Console.WriteLine("[x] Received: {0}", rm.Name);
        }
    }

    public class RedisMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }
}