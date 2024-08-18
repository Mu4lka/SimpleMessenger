using SimpleMessenger.Contracts.Dto;

namespace SimpleMessenger.Application.Interfaces;

public interface IMessagesService
{
    Task<ICollection<MessageDto>> GetMessagesSentAfterAsync(DateTime sentAfter);
    Task CreateMessageAsync(MessageDto messageDto);
}
