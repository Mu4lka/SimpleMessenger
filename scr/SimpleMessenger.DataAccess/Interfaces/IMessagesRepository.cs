using SimpleMessenger.Domain;

namespace SimpleMessenger.DataAccess.Interfaces;

public interface IMessagesRepository
{
    Task<ICollection<Message>> GetMessagesInTheLastMinutesAsync(int minutes);
    Task CreateAsync(Message message);
}
