using System;
using System.Text;
using RabbitMQ.Client;

namespace ForestApp_IdentifiyApi_RabbitMq
{
    public class Publisher
    {

        private readonly RabbitMqService _rabbitMQService;

        public Publisher(RabbitMqService rabbitMqService)
        {
            _rabbitMQService = rabbitMqService;
        }

        public void OnPublish(string queueName, string message)
        {
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                //kanal olusturma
                using (var channel = connection.CreateModel())
                {
                    //kuyruk olusturma 
                    channel.QueueDeclare(queueName, false, false, false, null);
                    //rabbitmq gönderme
                    channel.BasicPublish("", queueName, body: Encoding.UTF8.GetBytes(message));
                    Console.WriteLine("{0} queue'su üzerine, \"{1}\" mesajı yazıldı.", queueName, message);
                }
            }
        }
    }
}
