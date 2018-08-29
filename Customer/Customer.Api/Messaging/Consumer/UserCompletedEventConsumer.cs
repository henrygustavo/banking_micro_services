namespace Customer.Api.Messaging.Consumer
{
    using Common.Api.Messaging;
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;


    public class UserCompletedEventConsumer : IConsumer<UserCompledEvent>
    {
        private readonly ILogger<UserCompletedEventConsumer> _logger;
        public UserCompletedEventConsumer(ILogger<UserCompletedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UserCompledEvent> context)
        {
            _logger.LogWarning("We are in consume method now...");
            _logger.LogWarning("UserId:" + context.Message.UserId);

            return Task.Run(() =>
            {
                return context.Message.UserId;
            });  
        }
    }
}
