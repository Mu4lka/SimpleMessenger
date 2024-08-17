using System.ComponentModel.DataAnnotations;

namespace SimpleMessenger.Contracts.Requests;

/// <summary> Запрос на отправку сообщения </summary>
public class SendMessageRequest
{
    /// <summary> Сообщение </summary>
    public string Content { get; set; } = default!;

    /// <summary> Порядковый номер </summary>
    public int SequenceNumber { get; set; }
}
