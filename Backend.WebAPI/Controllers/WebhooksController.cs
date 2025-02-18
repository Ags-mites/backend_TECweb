using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Channels;

namespace Backend.WebAPI.Controllers
{
    [Route("api/webhooks")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        private static readonly ConcurrentBag<Channel<string>> _clients = new();

        [HttpGet("chat")]
        public async Task Get()
        {
            Response.Headers.Append("Content-Type", "text/event-stream");
            var channel = Channel.CreateUnbounded<string>();
            _clients.Add(channel);
            await foreach (var message in channel.Reader.ReadAllAsync())
            {
                await Response.WriteAsync($"data: {message}\n\n");
                await Response.Body.FlushAsync();
            }
            _clients.TryTake(out _);
        }

        [HttpPost("chat/send")]
        public IActionResult SendMessage([FromBody] ChatWebhookPayload payload)
        {
            var message = JsonSerializer.Serialize(payload.Message);
            foreach (var client in _clients)
            {
                client.Writer.TryWrite(message);
            }
            return Ok();
        }
    }

    public class ChatWebhookPayload
    {
        public string Message { get; set; } = string.Empty;
    }
}
