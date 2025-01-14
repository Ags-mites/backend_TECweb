using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/webhooks")]
public class WebhooksController : ControllerBase
{
    private readonly string _secretKey;

    public WebhooksController(IConfiguration configuration)
    {
        _secretKey = configuration["WebhookSettings:SecretKey"];
    }

    [HttpPost]
    public IActionResult ReceiveWebhook([FromBody] ChatWebhookPayload payload, [FromHeader(Name = "X-Secret-Key")] string secretKey)
    {
        if (secretKey != _secretKey)
        {
            return Unauthorized("Clave secreta inválida.");
        }

        switch (payload.Event)
        {
            case "message_received":
                Console.WriteLine($"Mensaje recibido de usuario {payload.UserId}: {payload.Message}");
                break;
            default:
                Console.WriteLine($"Evento no reconocido: {payload.Event}");
                break;
        }

        return Ok(new { status = "success" });
    }
}
