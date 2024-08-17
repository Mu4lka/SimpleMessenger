namespace SimpleMessenger.Domain;

/// <summary>
/// Сообщение
/// </summary>
public class Message : Entity<Guid>
{
    /// <summary> Контент сообщения </summary>
    public required string Content { get; init; } = default!;

    /// <summary> Дата создания </summary>
    public required DateTime CreatedDate { get; init; }

    /// <summary> Порядковый номер </summary>
    public required int SequenceNumber { get; init; }
}
