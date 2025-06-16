/// <summary>
/// Реализация репозитория клиентов в памяти
/// </summary>
public class CustomerInMemoryRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public IEnumerable<Customer> GetAll() => _customers;

    public Customer GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);

    public void Add(Customer customer) => _customers.Add(customer);

    public void Update(Customer customer)
    {
        var existing = GetById(customer.Id);
        if (existing != null)
        {
            existing.PassportNumber = customer.PassportNumber;
            existing.FullName = customer.FullName;
            existing.BirthDate = customer.BirthDate;
        }
    }

    public Customer GetByPassport(string passportNumber) =>
        _customers.FirstOrDefault(c => c.PassportNumber == passportNumber);

    public IEnumerable<Customer> GetByFullName(string namePart) =>
        _customers.Where(c => c.FullName.Contains(namePart, StringComparison.OrdinalIgnoreCase));
}