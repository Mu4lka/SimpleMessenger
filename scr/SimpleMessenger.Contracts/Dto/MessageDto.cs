namespace SimpleMessenger.Contracts.Dto;

/// <summary>
/// Dto сообщения
/// </summary>
/// <param name="content">Контент сообщения</param>
/// <param name="createdDate">Дата создания</param>
/// <param name="sequenceNumber">Порядковый номер</param>
public class MessageDto(
    string content,
    DateTime createdDate,
    int sequenceNumber)
{
    /// <summary>
    /// Контент сообщения
    /// </summary>
    public string Content { get; set; } = content;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; } = createdDate;

    /// <summary>
    /// Порядковый номер
    /// </summary>
    public int SequenceNumber { get; set; } = sequenceNumber;
}
