using SimpleMessenger.Contracts.Dto;

namespace Infrastucture.Interfaces;

public interface IMessagesService
{
    Task<ICollection<MessageDto>> GetMessagesSentAfterAsync(DateTime sentAfter);
    Task CreateMessageAsync(MessageDto messageDto);
}
