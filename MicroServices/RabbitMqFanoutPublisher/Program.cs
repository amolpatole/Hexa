using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMqFanoutPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "fanout-exch",
                type: ExchangeType.Fanout,
                durable: false,
                autoDelete: false,
                arguments: null);

            while (true)
            {
                Console.Write("Enter the message (Empty to exit): ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    break;
                }
                var payload = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "fanout-exch",
                    routingKey: "",
                    mandatory: false,
                    basicProperties: null,
                    body: payload);
            }

        }
    }
}
