/// <summary>
/// Представляет клиента службы проката
/// </summary>
public class Customer
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер паспорта клиента
    /// </summary>
    public string PassportNumber { get; set; }

    /// <summary>
    /// ФИО клиента
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Дата рождения клиента
    /// </summary>
    public DateTime BirthDate { get; set; }
}
// моя лаба
