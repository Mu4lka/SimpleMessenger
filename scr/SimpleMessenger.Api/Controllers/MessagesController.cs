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
    /// Получить сообщения за определенный диапазон
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<GetMessagesResponse>> GetMessagesForRangeAsync(
        [FromQuery(Name = "startDate")] DateTime startDate,
        [FromQuery(Name = "endDate")] DateTime endDate)
    {
        var localStartDate = TimeZoneInfo.ConvertTimeFromUtc(startDate, TimeZoneInfo.Local);
        var localEndDate = TimeZoneInfo.ConvertTimeFromUtc(endDate, TimeZoneInfo.Local);

        var messageDtos = await _service.GetMessagesForRangeAsync(localStartDate, localEndDate);

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
