using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PixelService.Domain.Entities;
using PixelService.Domain.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace PixelService.Infrastructure
{
    public class StorageService : IStorageService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public StorageService(IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public async Task StoreUserInformationAsync(UserInformation userInformation)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQSettings.HostName,
                Port = _rabbitMQSettings.Port,
                UserName = _rabbitMQSettings.UserName,
                Password = _rabbitMQSettings.Password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _rabbitMQSettings.QueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var pixelJson = JsonConvert.SerializeObject(userInformation);
            var body = Encoding.UTF8.GetBytes(pixelJson);

            channel.BasicPublish(exchange: "",
                                 routingKey: _rabbitMQSettings.QueueName,
                                 basicProperties: null,
                                 body: body);
        }
    }


}