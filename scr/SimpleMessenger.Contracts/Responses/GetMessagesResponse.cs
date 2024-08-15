using SimpleMessenger.Contracts.Dto;

namespace SimpleMessenger.Contracts.Responses;

internal class GetMessagesResponse
{
    public ICollection<MessageDto> Messages { get; set; } = default!;
}
