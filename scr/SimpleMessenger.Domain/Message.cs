namespace SimpleMessenger.Domain;

/// <summary>
/// Сообщение
/// </summary>
/// <param name="id"> Идентификатор </param>
/// <param name="content"> Контент сообщения </param>
/// <param name="createdDate"> Дата создания </param>
/// <param name="sequenceNumber"> Порядковый номер </param>
public class Message(
    Guid id,
    string content,
    DateTime createdDate,
    int sequenceNumber) : Entity<Guid>(id)
{
    /// <summary> Контент сообщения </summary>
    public string Content { get; init; } = content;

    /// <summary> Дата создания </summary>
    public DateTime CreatedDate { get; init; } = createdDate;

    /// <summary> Порядковый номер </summary>
    public int SequenceNumber { get; init; } = sequenceNumber;
}
