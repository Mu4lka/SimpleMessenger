using Microsoft.AspNetCore.SignalR;
using SimpleMessenger.Contracts.Dto;

namespace SimpleMessenger.Api.Hubs;

public class MessageHub : Hub
{
    public Task SendMessageAsync(MessageDto messageDto)
        => Clients.All.SendAsync("receiveMessage", messageDto);
}