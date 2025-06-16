/// <summary>
/// Реализация репозитория транспортных средств в памяти
/// </summary>
public class VehicleInMemoryRepository : IVehicleRepository
{
    private readonly List<Vehicle> _vehicles = new();

    public IEnumerable<Vehicle> GetAll() => _vehicles;

    public Vehicle GetById(int id) => _vehicles.FirstOrDefault(v => v.Id == id);

    public void Add(Vehicle vehicle) => _vehicles.Add(vehicle);

    public void Update(Vehicle vehicle)
    {
        var existing = GetById(vehicle.Id);
        if (existing != null)
        {
            existing.LicensePlate = vehicle.LicensePlate;
            existing.Model = vehicle.Model;
            existing.Color = vehicle.Color;
            existing.IsAvailable = vehicle.IsAvailable;
        }
    }
}