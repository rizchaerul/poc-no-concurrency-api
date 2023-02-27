using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace QueueFinal
{
    public class Message
    {
        public int Delay { get; set; }
    }

    public class MessageResult
    {
        public string Text { get; set; } = string.Empty;
    }

    public class MessageConsumer : IConsumer<Message>
    {
        readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Message> context)
        {
            await Task.Delay(context.Message.Delay);

            await context.RespondAsync(new MessageResult
            {
                Text = "Balikan data ke controller"
            });
        }
    }
}
