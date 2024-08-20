using SimpleMessenger.Domain.Entities;

namespace SimpleMessenger.Domain;

public interface IMessagesRepository
{
    Task<ICollection<Message>> GetMessagesForRangeAsync(DateTime startDate, DateTime endDate);
    Task CreateMessageAsync(Message message);
}
