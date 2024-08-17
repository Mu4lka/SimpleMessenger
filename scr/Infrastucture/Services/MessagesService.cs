using Infrastucture.Interfaces;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.DataAccess.Interfaces;
using SimpleMessenger.Domain;

namespace Infrastucture.Services;

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
            new Message() {
                Id = Guid.NewGuid(),
                Content = messageDto.Content,
                CreatedDate = messageDto.CreatedDate,
                SequenceNumber = messageDto.SequenceNumber
            });
}
