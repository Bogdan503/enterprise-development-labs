/// <summary>
/// Представляет запись о прокате автомобиля
/// </summary>
public class RentalRecord
{
    /// <summary>
    /// Уникальный идентификатор записи о прокате
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор арендованного транспортного средства
    /// </summary>
    public int VehicleId { get; set; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Идентификатор пункта выдачи
    /// </summary>
    public int RentalPointId { get; set; }

    /// <summary>
    /// Дата и время выдачи автомобиля
    /// </summary>
    public DateTime RentalDate { get; set; }

    /// <summary>
    /// Планируемая дата возврата
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Фактическая дата возврата (null если автомобиль еще не возвращен)
    /// </summary>
    public DateTime? ReturnDate { get; set; }

    /// <summary>
    /// Идентификатор пункта возврата (может отличаться от пункта выдачи)
    /// </summary>
    public int? ReturnPointId { get; set; }
}