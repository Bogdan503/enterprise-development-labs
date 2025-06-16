/// <summary>
/// Интерфейс сервиса для работы с прокатом автомобилей
/// </summary>
public interface IRentalService
{
    /// <summary>
    /// Получить все транспортные средства
    /// </summary>
    IEnumerable<Vehicle> GetAllVehicles();

    /// <summary>
    /// Получить клиентов, арендовавших указанную модель (сортировка по ФИО)
    /// </summary>
    IEnumerable<Customer> GetCustomersByVehicleModel(string model);

    /// <summary>
    /// Получить автомобили, находящиеся в аренде
    /// </summary>
    IEnumerable<Vehicle> GetRentedVehicles();

    /// <summary>
    /// Получить топ-5 самых арендуемых автомобилей
    /// </summary>
    IEnumerable<Vehicle> GetTop5MostRentedVehicles();

    /// <summary>
    /// Получить количество аренд для каждого автомобиля
    /// </summary>
    Dictionary<Vehicle, int> GetRentalCountsForAllVehicles();

    /// <summary>
    /// Получить самые популярные пункты проката (сортировка по названию)
    /// </summary>
    IEnumerable<RentalPoint> GetMostPopularRentalPoints();
}