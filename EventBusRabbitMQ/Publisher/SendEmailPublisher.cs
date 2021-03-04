using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ.Publisher
{
    public class SendEmailPublisher
    {
        private readonly IRabbitMQConnection _connection;

        public SendEmailPublisher(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void PublishEmail(string queueName, string customMessage)
        {
            using (var channel = _connection.CreateModel())
            {
                //kuyruk olusturma 
                channel.QueueDeclare(queueName, false, false, false, null);
                var message = Encoding.UTF8.GetBytes(customMessage);
                //properties
                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;
                //
                channel.ConfirmSelect();
                //rabbitmq gönderme

                channel.BasicPublish(exchange:"", queueName, body:message,mandatory:true,basicProperties:properties);
                Console.WriteLine("{0} queue'su üzerine, \"{1}\" mesajı yazıldı.", queueName, message);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("{0} queue'su üzerine, \"{1}\" mesajı yazıldı. 12121", queueName, message);
                };
                channel.ConfirmSelect();

            }
        }
    }
}
