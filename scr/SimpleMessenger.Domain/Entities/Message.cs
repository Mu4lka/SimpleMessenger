namespace SimpleMessenger.Domain.Entities;

/// <summary>
/// Сообщение
/// </summary>
public class Message
{
    public Message(string content, DateTime createdDate, int sequenceNumber)
    {
        Id = Guid.NewGuid();
        Content = content;
        CreatedDate = createdDate;
        SequenceNumber = sequenceNumber;
    }

    protected Message() { }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; } = default!;

    /// <summary>
    /// Контент сообщения
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; }

    /// <summary>
    /// Порядковый номер
    /// </summary>
    public int SequenceNumber { get; }
}
