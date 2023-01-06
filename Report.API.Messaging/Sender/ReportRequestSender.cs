using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.API.Messaging.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Report.API.Messaging.Sender
{
    public class ReportRequestSender : IReportRequestSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _pollingQueueName;
        private readonly string _username;
        private IConnection _connection;

        public ReportRequestSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _pollingQueueName = rabbitMqOptions.Value.PollingQueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;

            CreateConnection();
        }

        public Task SendReportRequest(string location)
        {
            var json = JsonConvert.SerializeObject(location);

            return SendToQueue(_queueName, json);
        }

        public Task SendVote(string vote)
        {
            var json = JsonConvert.SerializeObject(vote);

            return SendToQueue(_pollingQueueName, json);
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
    }
}