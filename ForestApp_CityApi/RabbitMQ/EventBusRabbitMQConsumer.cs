using EventBusRabbitMQ;
using EventBusRabbitMQ.Consts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForestApp_CityApi.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare("test", false, false, false, null);
            var consumer = new EventingBasicConsumer(channel);

            channel.QueueDeclare(EventBusConsts.SendEmailQueque, false, false, false, null);
            channel.BasicConsume(queue: EventBusConsts.SendEmailQueque, autoAck: true, consumer: consumer);
            consumer.Received += ReceivedEvent;

            // channel.BasicConsume(EventBusConsts.SendEmailQueque, true, consumer);
        }
        public  void ReceivedEvent(object sender,BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConsts.SendEmailQueque)
            {
                string serializeJson = Encoding.UTF8.GetString(e.Body.Span);
                Thread.Sleep(5000);
                Console.WriteLine($"Email Başarıyla  gönderildi");
            }
        }
        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
