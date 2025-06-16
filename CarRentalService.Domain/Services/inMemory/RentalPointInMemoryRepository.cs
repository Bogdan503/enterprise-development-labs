/// <summary>
/// Реализация репозитория пунктов проката в памяти
/// </summary>
public class RentalPointInMemoryRepository : IRentalPointRepository
{
    private readonly List<RentalPoint> _rentalPoints = new();

    public IEnumerable<RentalPoint> GetAll() => _rentalPoints;

    public RentalPoint GetById(int id) => _rentalPoints.FirstOrDefault(rp => rp.Id == id);

    public void Add(RentalPoint rentalPoint) => _rentalPoints.Add(rentalPoint);

    public void Update(RentalPoint rentalPoint)
    {
        var existing = GetById(rentalPoint.Id);
        if (existing != null)
        {
            existing.Name = rentalPoint.Name;
            existing.Address = rentalPoint.Address;
        }
    }

    public RentalPoint GetByName(string name) =>
        _rentalPoints.FirstOrDefault(rp => rp.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public Dictionary<int, int> GetRentalCountsPerPoint()
    {
        // В реальной реализации здесь будет логика подсчета аренд по пунктам
        return new Dictionary<int, int>();
    }
}