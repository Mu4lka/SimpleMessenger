using SimpleMessenger.Contracts.Dto;

namespace SimpleMessenger.Application.Interfaces;

public interface IMessagesService
{
    Task<ICollection<MessageDto>> GetMessagesForRangeAsync(DateTime startDate, DateTime endDate);
    Task CreateMessageAsync(MessageDto messageDto);
}
