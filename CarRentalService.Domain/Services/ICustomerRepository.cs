/// <summary>
/// Интерфейс репозитория для работы с клиентами
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    IEnumerable<Customer> GetAll();

    /// <summary>
    /// Получить клиента по идентификатору
    /// </summary>
    Customer GetById(int id);

    /// <summary>
    /// Добавить нового клиента
    /// </summary>
    void Add(Customer customer);

    /// <summary>
    /// Обновить информацию о клиенте
    /// </summary>
    void Update(Customer customer);

    /// <summary>
    /// Получить клиента по номеру паспорта
    /// </summary>
    Customer GetByPassport(string passportNumber);

    /// <summary>
    /// Получить клиентов по ФИО (поиск по подстроке)
    /// </summary>
    IEnumerable<Customer> GetByFullName(string namePart);
}