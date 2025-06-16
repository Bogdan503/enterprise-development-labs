

/// <summary>
/// Интерфейс репозитория для работы с записями о прокате
/// </summary>
public interface IRentalRecordRepository
{
    /// <summary>
    /// Получить все записи о прокате
    /// </summary>
    IEnumerable<RentalRecord> GetAll();

    /// <summary>
    /// Добавить новую запись о прокате
    /// </summary>
    void Add(RentalRecord record);

    /// <summary>
    /// Обновить запись о прокате (например, при возврате автомобиля)
    /// </summary>
    void Update(RentalRecord record);

    /// <summary>
    /// Получить активные аренды (где ReturnDate == null)
    /// </summary>
    IEnumerable<RentalRecord> GetActiveRentals();

    /// <summary>
    /// Получить количество аренд для каждого автомобиля
    /// </summary>
    Dictionary<int, int> GetRentalCountsPerVehicle();

    /// <summary>
    /// Получить записи по идентификатору автомобиля
    /// </summary>
    IEnumerable<RentalRecord> GetByVehicleId(int vehicleId);

    /// <summary>
    /// Получить записи по модели автомобиля
    /// </summary>
    IEnumerable<RentalRecord> GetByVehicleModel(string model);
    object Setup(Func<object, object> value);
}