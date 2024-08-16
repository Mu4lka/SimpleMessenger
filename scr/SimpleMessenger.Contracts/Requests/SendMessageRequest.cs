using System.ComponentModel.DataAnnotations;

namespace SimpleMessenger.Contracts.Requests;

/// <summary> Запрос на отправку сообщения </summary>
public class SendMessageRequest
{
    /// <summary> Сообщение </summary>
    [Required]
    public string Content { get; set; } = default!;

    /// <summary> Порядковый номер </summary>
    [Required]
    public int SequenceNumber { get; set; }
}
