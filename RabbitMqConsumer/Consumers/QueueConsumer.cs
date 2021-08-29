using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQConsumer.Consumers
{
    public static class QueueConsumer
    {
          public static void Consume(IModel channel)
        {
           /*Creating Queue*/
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
             /*Creating Queue*/
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queue", true, consumer);
            Console.WriteLine("Consumer is up and running...");
        }
    }
}
