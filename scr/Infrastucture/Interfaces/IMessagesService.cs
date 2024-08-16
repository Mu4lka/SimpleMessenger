using SimpleMessenger.Contracts.Dto;

namespace Infrastucture.Interfaces;

public interface IMessagesService
{
    Task<ICollection<MessageDto>> GetMessagesInLastMinutesAsync(int minutes);
    Task CreateMessageAsync(MessageDto messageDto);
}
