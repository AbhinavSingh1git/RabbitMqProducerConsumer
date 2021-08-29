using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQProducer.Publishers
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var count = 1;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "demo-queue", null, body);
                Console.WriteLine($"Message pushed with  Count: {count}");
                count++;
                Thread.Sleep(1000);//So that it do not continuosly produce it
            }
        }
    }
}