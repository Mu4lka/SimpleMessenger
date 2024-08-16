namespace SimpleMessenger.Domain;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="TId"></typeparam>
public class Entity<TId>
{
    /// <summary> Идентификатор </summary>
    public TId Id { get; init; }
}
