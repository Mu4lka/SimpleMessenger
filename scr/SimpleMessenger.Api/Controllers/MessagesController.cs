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
    [HttpGet("{minutes:int}")]
    public async Task<ActionResult<ICollection<MessageDto>>> GetMessagesInLastMinutesAsync([FromQuery] int minutes)
    {
        var messageDtos = await _service.GetMessagesInLastMinutesAsync(minutes);

        return Ok(messageDtos);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageAsync([FromBody] SendMessageRequest request)
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
