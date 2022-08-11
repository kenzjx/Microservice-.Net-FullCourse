using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;

            var factory = new  ConnectionFactory(){HostName = _configuration["RabbitMqHost"],
            Port = int.Parse(_configuration["RabbitMqPort"])};
            try
            {
                _connection = factory.CreateConnection();
                
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine($"--> RabbitMq to Message");
            }
            catch (System.Exception ex)
            {
                
                Console.WriteLine($"-->> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine($"--> RabbitMq Connection Shutdown");
        }

        public void PushlishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            
        }
    }
}