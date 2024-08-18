using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleMessenger.Api.Hubs;
using SimpleMessenger.Application.Interfaces;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.Contracts.Requests;
using SimpleMessenger.Contracts.Responses;

namespace SimpleMessenger.Api.Controllers;

[Route("api/messages")]
[ApiController]
public class MessagesController(
    IMessagesService _service,
    IHubContext<MessageHub> _hubContext) : ControllerBase
{
    /// <summary>
    /// Получить сообщения отправленные после определенного времени
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<GetMessagesResponse>> GetMessagesSentAfterAsync([FromQuery(Name = "sent-after")] DateTime sentAfter)
    {
        var localSentAfter = TimeZoneInfo.ConvertTimeFromUtc(sentAfter, TimeZoneInfo.Local);
        var messageDtos = await _service.GetMessagesSentAfterAsync(localSentAfter);

        return Ok(new GetMessagesResponse { Messages = messageDtos });
    }

    /// <summary>
    /// Отправить сообщение
    /// </summary>
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
