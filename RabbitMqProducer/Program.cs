using System;
using RabbitMQ.Client;
using RabbitMQProducer.Publishers;

namespace RabbitMqProducer
{
    class Program
    {
        static void Main(string[] args)
        {
           
             var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //QueueProducer.Publish(channel);
           //  DirectExchangePublisher.Publish(channel);
            //TopicExchangePublisher.Publish(channel);
          //  HeaderExchangePublisher.Publish(channel);
            FanoutExchangePublisher.Publish(channel);
        }
    }
}
