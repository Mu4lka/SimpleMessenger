using SimpleMessenger.Domain.Entities;

namespace SimpleMessenger.Domain;

public interface IMessagesRepository
{
    Task<ICollection<Message>> GetMessagesSentAfterAsync(DateTime sentAfter);
    Task CreateMessageAsync(Message message);
}
