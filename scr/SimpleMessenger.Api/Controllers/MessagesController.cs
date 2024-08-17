using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleMessenger.Api.Hubs;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.Contracts.Requests;

namespace SimpleMessenger.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController(IMessagesService _service, IHubContext<MessageHub> _hubContext) : ControllerBase
{
    /// <summary>
    /// Получить сообщения в последние минуты
    /// </summary>
    /// <param name="minutes"></param>
    /// <returns></returns>
    [HttpGet("{minutes:int}")]
    public async Task<ActionResult<ICollection<MessageDto>>> GetMessagesInLastMinutesAsync(int minutes)
    {
        if (minutes < 0)
            return BadRequest("The value for minutes cannot be negative");

        var messageDtos = await _service.GetMessagesInLastMinutesAsync(minutes);

        return Ok(messageDtos);
    }

    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SendMessageAsync(SendMessageRequest request)
    {
        var messageDto = new MessageDto(
                request.Content,
                DateTime.Now,
                request.SequenceNumber
                );

        await _service.CreateMessageAsync(messageDto);

        await _hubContext.Clients.All.SendAsync("receiveMessage", messageDto);

        return Ok();
    }
}
