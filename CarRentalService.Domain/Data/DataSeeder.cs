/// <summary>
/// Класс для заполнения системы тестовыми данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Заполнить систему тестовыми данными
    /// </summary>
    public static void Seed(
        IVehicleRepository vehicleRepo,
        IRentalPointRepository pointRepo,
        ICustomerRepository customerRepo,
        IRentalRecordRepository rentalRepo)
    {
        // Добавление тестовых пунктов проката
        var points = new List<RentalPoint>
        {
            new() { Id = 1, Name = "Центральный", Address = "ул. Центральная, 1" },
            new() { Id = 2, Name = "Северный", Address = "ул. Северная, 15" }
        };
        points.ForEach(pointRepo.Add);

        // Добавление тестовых автомобилей
        var vehicles = new List<Vehicle>
        {
            new() { Id = 1, LicensePlate = "А123БВ", Model = "Toyota Camry", Color = "Черный", IsAvailable = true },
            new() { Id = 2, LicensePlate = "Х456УК", Model = "Lada Vesta", Color = "Белый", IsAvailable = false }
        };
        vehicles.ForEach(vehicleRepo.Add);

        // Добавление тестовых клиентов
        var customers = new List<Customer>
        {
            new() { Id = 1, PassportNumber = "1234567890", FullName = "Иванов Иван Иванович", BirthDate = new DateTime(1985, 5, 10) },
            new() { Id = 2, PassportNumber = "0987654321", FullName = "Петров Петр Петрович", BirthDate = new DateTime(1990, 7, 15) }
        };
        customers.ForEach(customerRepo.Add);

        // Добавление тестовых записей о прокате
        var rentals = new List<RentalRecord>
        {
            new() { Id = 1, VehicleId = 2, CustomerId = 1, RentalPointId = 1,
                   RentalDate = DateTime.Now.AddDays(-3), DueDate = DateTime.Now.AddDays(7) }
        };
        rentals.ForEach(rentalRepo.Add);
    }
}