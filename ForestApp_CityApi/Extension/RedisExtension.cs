using ForestApp_CityApi.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_CityApi.Extension
{
    public static class RedisExtension
    {
        public static EventBusRabbitMQConsumer Listener { get; set; }
        public static IApplicationBuilder UseRabbitMQListener(this IApplicationBuilder app)
        {
            //servis örneğinin alınması
            //
            /*
             Allows consumers to be notified of application lifetime events.
             */
            Listener = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);
            return app;
        }
        private static void OnStarted()
        {
            Listener.Consume();
        }
        private static void OnStopping()
        {
            Console.WriteLine("Duruyor");
            Listener.Disconnect();
        }
    }
}
