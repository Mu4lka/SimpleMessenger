namespace SimpleMessenger.Domain;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="TId"></typeparam>
/// <param name="id"> Идентификатор </param>
public class Entity<TId>(TId id)
{
    /// <summary> Идентификатор </summary>
    public TId Id { get; init; } = id;
}
