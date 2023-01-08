using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.API.Domain.Dto;
using Report.API.Messaging.Options;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Report.API.Cache.RedisCache;
using Microsoft.Extensions.Hosting;

namespace Report.API.Messaging.Sender
{
    public class ReportRequestSender : BackgroundService
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _pollingQueueName;
        private readonly string _username;
        private IConnection _connection;
        private readonly ICacheProvider _cacheProvider;

        public ReportRequestSender(IOptions<RabbitMqConfiguration> rabbitMqOptions, ICacheProvider cacheProvider)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _pollingQueueName = rabbitMqOptions.Value.PollingQueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _cacheProvider = cacheProvider;
            _cacheProvider.OnCacheUpdated += _cacheProvider_OnCacheUpdated;
            CreateConnection();
        }

        private void _cacheProvider_OnCacheUpdated(object sender, Domain.EventHandlers.CacheUpdatedEventargs e)
        {
            if (e.UpdatedKey == Enums.DistirubedCacheKey.ElectionResult)
            {
                PublishElectionResult(e.Value);
            }
        }

        public Task SendReportRequest(string location)
        {
            var json = JsonConvert.SerializeObject(location);

            return SendToQueue(_queueName, json);
        }

        private void PublishElectionResult(string report)
        {
            SendToQueue(_pollingQueueName, report);
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

        private Task SendToQueue(string queueName, string jsonMessage)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(jsonMessage);

                    channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                }
            }
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}