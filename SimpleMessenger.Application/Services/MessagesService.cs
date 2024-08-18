using SimpleMessenger.Application.Interfaces;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.Domain;
using SimpleMessenger.Domain.Entities;

namespace SimpleMessenger.Application.Services;

public class MessagesService(IMessagesRepository _repository) : IMessagesService
{
    public async Task<ICollection<MessageDto>> GetMessagesSentAfterAsync(DateTime sentAfter)
    {
        var messages = await _repository.GetMessagesSentAfterAsync(sentAfter);
        return messages
            .Select(m => new MessageDto(m.Content, m.CreatedDate, m.SequenceNumber))
            .ToList();
    }

    public Task CreateMessageAsync(MessageDto messageDto)
        => _repository.CreateMessageAsync(
            new Message(
                messageDto.Content,
                messageDto.CreatedDate,
                messageDto.SequenceNumber
                ));
}
