using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMqFanoutConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "fanout-exch",
              type: ExchangeType.Fanout,
              durable: false,
              autoDelete: false,
              arguments: null);

            channel.QueueDeclare(args[0], durable: false, exclusive: false, autoDelete: false);
            channel.QueueBind(args[0], "fanout-exch", "", null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, eq) =>
            {
                var message = Encoding.UTF8.GetString(eq.Body);
                Console.WriteLine($"Message received:{message}");
            };
            channel.BasicConsume(args[0], true, consumer);

            Console.WriteLine("Waiting for message... Press ENTER to exit");
            Console.ReadLine();

            channel.Dispose();
            connection.Dispose();
        }
    }
}
