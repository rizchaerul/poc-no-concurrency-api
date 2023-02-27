using MassTransit;
using Microsoft.AspNetCore.Mvc;
using QueueFinal;

namespace QueueFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly IBus _bus;
        readonly IRequestClient<Message> _client;

        public TestController(IBus bus, IRequestClient<Message> client)
        {
            _bus = bus;
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult> ExecuteAsync(int delay, CancellationToken stoppingToken)
        {
            // Publish
            // await _bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

            // Wait for result
            var response = await _client.GetResponse<MessageResult>(new Message { Delay = delay }, stoppingToken);
            Console.WriteLine(response);

            return Ok();
        }
    }
}
