using System;
using RabbitMQ.Client;
using RabbitMQConsumer.Consumers;

namespace RabbitMqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection(); //step1
            using var channel = connection.CreateModel(); //step2
             //QueueConsumer.Consume(channel);
             //DirectExchangeConsumer.Consume(channel);
            //TopicExchangeConsumer.Consume(channel);
            //HeaderExchangeConsumer.Consume(channel);
            FanoutExchangeConsumer.Consume(channel);
            Console.ReadLine();
        }
    }
}
