namespace Report.API.Messaging.Options
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }

        public string QueueName { get; set; }

        public string PollingQueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public bool Enabled { get; set; }
    }
}