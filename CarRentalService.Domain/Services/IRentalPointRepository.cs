/// <summary>
/// Интерфейс репозитория для работы с пунктами проката
/// </summary>
public interface IRentalPointRepository
{
    /// <summary>
    /// Получить все пункты проката
    /// </summary>
    IEnumerable<RentalPoint> GetAll();

    /// <summary>
    /// Получить пункт проката по идентификатору
    /// </summary>
    RentalPoint GetById(int id);

    /// <summary>
    /// Добавить новый пункт проката
    /// </summary>
    void Add(RentalPoint rentalPoint);

    /// <summary>
    /// Обновить информацию о пункте проката
    /// </summary>
    void Update(RentalPoint rentalPoint);

    /// <summary>
    /// Получить пункт проката по названию
    /// </summary>
    RentalPoint GetByName(string name);

    /// <summary>
    /// Получить количество аренд для каждого пункта проката
    /// </summary>
    Dictionary<int, int> GetRentalCountsPerPoint();
}