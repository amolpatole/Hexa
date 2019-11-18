using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMqAdvancedConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length < 2)
            //{
            //    Console.WriteLine("Invalid number of arguments");
            //    return;
            //}

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var arguments = new Dictionary<string, object>()
            {
                { "x-message-ttl", 60000 },
                { "x-expires", 30*60*1000 }
            };

            channel.QueueDeclare("demoq", durable: false, exclusive: false, autoDelete: false, arguments: arguments);

            channel.QueueBind("demoq", "demo-exch", "", null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, eq) =>
            {
                var message = Encoding.UTF8.GetString(eq.Body);
                Console.WriteLine($"Message received:{message}");
                channel.BasicAck(eq.DeliveryTag, multiple: false); // Explicit acknowledgement
            };
            channel.BasicConsume(queue:"demoq", autoAck:false, consumer:consumer); // disable auto ack

            Console.WriteLine("Waiting for message... Press ENTER to exit");
            Console.ReadLine();

            channel.Dispose();
            connection.Dispose();
        }
    }
}
