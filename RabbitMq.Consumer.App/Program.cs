

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMq.Consumer.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
                ConnectionFactory factory = new ConnectionFactory();
                factory.Uri = new Uri("amqps://tlsetvpf:Yw_QZeK2t65lycGvDKdexnMe-u_DEfxv@cow.rmq2.cloudamqp.com/tlsetvpf");

                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {

                var listenSwitch = true;
                while (listenSwitch)
                {
                    channel.QueueDeclare("TestQueue", false, false, true);
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("TestQueue", false, consumer);
                    consumer.Received += (sender, e) =>
                    {                      
                        Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
                    };
                }
                    
                }

        }
    }
}
