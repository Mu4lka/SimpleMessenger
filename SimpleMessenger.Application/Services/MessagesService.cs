using SimpleMessenger.Application.Interfaces;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.Domain;
using SimpleMessenger.Domain.Entities;

namespace SimpleMessenger.Application.Services;

public class MessagesService(IMessagesRepository _repository) : IMessagesService
{
    public async Task<ICollection<MessageDto>> GetMessagesForRangeAsync(DateTime startDate, DateTime endDate)
    {
        var messages = await _repository.GetMessagesForRangeAsync(startDate, endDate);
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
