using Infrastucture.Interfaces;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.DataAccess.Interfaces;
using SimpleMessenger.Domain;

namespace Infrastucture.Services;

public class MessagesService(IMessagesRepository _repository) : IMessagesService
{
    public async Task<ICollection<MessageDto>> GetMessagesInLastMinutesAsync(int minutes)
    {
        var messages = await _repository.GetMessagesInLastMinutesAsync(minutes);
        return messages
            .Select(m => new MessageDto(m.Content, m.CreatedDate, m.SequenceNumber))
            .ToList();
    }

    public Task SendMessageAsync(MessageDto messageDto)
    {
        _repository.CreateAsync(
            new Message(
                Guid.NewGuid(),
                messageDto.Content,
                messageDto.CreatedDate,
                messageDto.SequenceNumber
                ));
        return Task.CompletedTask;
    }
}
