using SimpleMessenger.Domain;

namespace SimpleMessenger.DataAccess.Interfaces;

public interface IMessagesRepository
{
    Task<ICollection<Message>> GetMessagesSentAfterAsync(DateTime sentAfter);
    Task CreateMessageAsync(Message message);
}
