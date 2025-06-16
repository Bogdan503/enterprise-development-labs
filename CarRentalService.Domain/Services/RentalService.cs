/// <summary>
/// Реализация сервиса для работы с прокатом автомобилей
/// </summary>
public class RentalService : IRentalService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRentalRecordRepository _rentalRecordRepository;
    private readonly IRentalPointRepository _rentalPointRepository;

    public RentalService(
        IVehicleRepository vehicleRepository,
        ICustomerRepository customerRepository,
        IRentalRecordRepository rentalRecordRepository,
        IRentalPointRepository rentalPointRepository)
    {
        _vehicleRepository = vehicleRepository;
        _customerRepository = customerRepository;
        _rentalRecordRepository = rentalRecordRepository;
        _rentalPointRepository = rentalPointRepository;
    }

    public IEnumerable<Vehicle> GetAllVehicles() => _vehicleRepository.GetAll();

    public IEnumerable<Customer> GetCustomersByVehicleModel(string model)
    {
        var records = _rentalRecordRepository.GetByVehicleModel(model);
        var customerIds = records.Select(r => r.CustomerId).Distinct();
        return customerIds.Select(id => _customerRepository.GetById(id))
                         .OrderBy(c => c.FullName);
    }

    public IEnumerable<Vehicle> GetRentedVehicles()
    {
        var activeRentals = _rentalRecordRepository.GetActiveRentals();
        return activeRentals.Select(r => _vehicleRepository.GetById(r.VehicleId));
    }

    public IEnumerable<Vehicle> GetTop5MostRentedVehicles()
    {
        var rentalCounts = _rentalRecordRepository.GetRentalCountsPerVehicle()
            .OrderByDescending(x => x.Value)
            .Take(5);

        return rentalCounts.Select(x => _vehicleRepository.GetById(x.Key));
    }

    public Dictionary<Vehicle, int> GetRentalCountsForAllVehicles()
    {
        var rentalCounts = _rentalRecordRepository.GetRentalCountsPerVehicle();
        return _vehicleRepository.GetAll()
            .ToDictionary(
                v => v,
                v => rentalCounts.TryGetValue(v.Id, out var count) ? count : 0
            );
    }

    public IEnumerable<RentalPoint> GetMostPopularRentalPoints()
    {
        throw new NotImplementedException();
    }
}