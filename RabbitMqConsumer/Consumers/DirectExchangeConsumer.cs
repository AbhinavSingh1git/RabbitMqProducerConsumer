using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQConsumer.Consumers
{
public static class DirectExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
             //Exchange Declare
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
             //queue Declare
            channel.QueueDeclare("demo-direct-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            
            //binding between exchange and queue
            channel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.init");
             //prefach count
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-direct-queue", true, consumer);
             Console.WriteLine("Consumer is up and running for Direct Exchange...");
            Console.ReadLine();
        }

    }

}