using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConnectionFactory _factory;
        private  IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory factory)
        {
            _factory = factory;
            if (!IsConnected)
            {
                TryConnect();
            }
        }
        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Not Connect");
            }
            else
            {
             return   _connection.CreateModel();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                return;
            }
            try
            {
                _connection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool TryConnect()
        {
            try
            {
                _connection = _factory.CreateConnection();
            }
            catch (BrokerUnreachableException )
            {
                Thread.Sleep(3000);
                _connection = _factory.CreateConnection();
            }
            if (IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
