using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusMessageServiceAPI;


[Route("api/[controller]")]
[ApiController]
public class RabbitMQController(
    IRabbitMQMessageSenderService<MissonMessage> missonRabbitMQ
    ) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMissonMessage(MissonMessage message, string queueName)
    {
        var response = await missonRabbitMQ.SendMessage(message, queueName);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}

