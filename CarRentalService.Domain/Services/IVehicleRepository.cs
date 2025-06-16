/// <summary>
/// Интерфейс репозитория для работы с транспортными средствами
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// Получить все транспортные средства
    /// </summary>
    IEnumerable<Vehicle> GetAll();

    /// <summary>
    /// Получить транспортное средство по идентификатору
    /// </summary>
    Vehicle GetById(int id);

    /// <summary>
    /// Добавить новое транспортное средство
    /// </summary>
    void Add(Vehicle vehicle);

    /// <summary>
    /// Обновить информацию о транспортном средстве
    /// </summary>
    void Update(Vehicle vehicle);
}