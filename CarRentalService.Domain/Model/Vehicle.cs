/// <summary>
/// Представляет транспортное средство в системе проката
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Уникальный идентификатор транспортного средства
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Регистрационный номер автомобиля
    /// </summary>
    public string LicensePlate { get; set; }

    /// <summary>
    /// Модель автомобиля
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Цвет автомобиля
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Флаг, указывающий доступен ли автомобиль для аренды
    /// </summary>
    public bool IsAvailable { get; set; }
}