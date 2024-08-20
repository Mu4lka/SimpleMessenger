using System.ComponentModel.DataAnnotations;

namespace SimpleMessenger.Contracts.Requests;

/// <summary>
/// Запрос на отправку сообщения
/// </summary>
public class SendMessageRequest
{
    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    [StringLength(128)]
    public string Content { get; set; } = default!;

    /// <summary>
    /// Порядковый номер
    /// </summary>
    [Required]
    [Range(0, int.MaxValue)]
    public int SequenceNumber { get; set; }
}
