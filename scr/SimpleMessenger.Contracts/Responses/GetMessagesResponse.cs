using SimpleMessenger.Contracts.Dto;

namespace SimpleMessenger.Contracts.Responses;

/// <summary>
/// Ответ на получение сообщений
/// </summary>
public class GetMessagesResponse
{
    /// <summary>
    /// Сообщения
    /// </summary>
    public ICollection<MessageDto> Messages { get; set; } = default!;
}
