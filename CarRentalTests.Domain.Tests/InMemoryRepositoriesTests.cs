using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class InMemoryRepositoriesTests
{
    // Тесты для VehicleInMemoryRepository
    public class VehicleInMemoryRepositoryTests
    {
        private readonly VehicleInMemoryRepository _repository;
        private readonly Vehicle _testVehicle;

        public VehicleInMemoryRepositoryTests()
        {
            _repository = new VehicleInMemoryRepository();
            _testVehicle = new Vehicle
            {
                Id = 1,
                LicensePlate = "A123BC",
                Model = "Toyota Camry",
                Color = "Black",
                IsAvailable = true
            };
        }

        [Fact]
        public void GetAll_Initially_ReturnsEmptyCollection()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_NonExistentId_ReturnsNull()
        {
            // Act
            var result = _repository.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_AddsVehicleToRepository()
        {
            // Act
            _repository.Add(_testVehicle);

            // Assert
            var result = _repository.GetAll().Single();
            Assert.Equal(_testVehicle, result);
        }

        [Fact]
        public void GetById_AfterAdding_ReturnsCorrectVehicle()
        {
            // Arrange
            _repository.Add(_testVehicle);

            // Act
            var result = _repository.GetById(_testVehicle.Id);

            // Assert
            Assert.Equal(_testVehicle, result);
        }

        [Fact]
        public void Update_ExistingVehicle_UpdatesProperties()
        {
            // Arrange
            _repository.Add(_testVehicle);
            var updatedVehicle = new Vehicle
            {
                Id = _testVehicle.Id,
                LicensePlate = "B456DE",
                Model = "Honda Accord",
                Color = "White",
                IsAvailable = false
            };

            // Act
            _repository.Update(updatedVehicle);
            var result = _repository.GetById(_testVehicle.Id);

            // Assert
            Assert.Equal(updatedVehicle.LicensePlate, result.LicensePlate);
            Assert.Equal(updatedVehicle.Model, result.Model);
            Assert.Equal(updatedVehicle.Color, result.Color);
            Assert.Equal(updatedVehicle.IsAvailable, result.IsAvailable);
        }

        [Fact]
        public void Update_NonExistentVehicle_DoesNothing()
        {
            // Arrange
            var initialCount = _repository.GetAll().Count();
            var nonExistentVehicle = new Vehicle { Id = 999 };

            // Act
            _repository.Update(nonExistentVehicle);

            // Assert
            Assert.Equal(initialCount, _repository.GetAll().Count());
        }
    }

    // Тесты для RentalPointInMemoryRepository
    public class RentalPointInMemoryRepositoryTests
    {
        private readonly RentalPointInMemoryRepository _repository;
        private readonly RentalPoint _testRentalPoint;

        public RentalPointInMemoryRepositoryTests()
        {
            _repository = new RentalPointInMemoryRepository();
            _testRentalPoint = new RentalPoint
            {
                Id = 1,
                Name = "Central Rental",
                Address = "123 Main St"
            };
        }

        [Fact]
        public void GetAll_Initially_ReturnsEmptyCollection()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_NonExistentId_ReturnsNull()
        {
            // Act
            var result = _repository.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_AddsRentalPointToRepository()
        {
            // Act
            _repository.Add(_testRentalPoint);

            // Assert
            var result = _repository.GetAll().Single();
            Assert.Equal(_testRentalPoint, result);
        }

        [Fact]
        public void GetByName_ExistingName_ReturnsCorrectRentalPoint()
        {
            // Arrange
            _repository.Add(_testRentalPoint);

            // Act
            var result = _repository.GetByName("central rental");

            // Assert
            Assert.Equal(_testRentalPoint, result);
        }

        [Fact]
        public void GetByName_NonExistentName_ReturnsNull()
        {
            // Act
            var result = _repository.GetByName("nonexistent");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_ExistingRentalPoint_UpdatesProperties()
        {
            // Arrange
            _repository.Add(_testRentalPoint);
            var updatedRentalPoint = new RentalPoint
            {
                Id = _testRentalPoint.Id,
                Name = "Updated Name",
                Address = "456 New St"
            };

            // Act
            _repository.Update(updatedRentalPoint);
            var result = _repository.GetById(_testRentalPoint.Id);

            // Assert
            Assert.Equal(updatedRentalPoint.Name, result.Name);
            Assert.Equal(updatedRentalPoint.Address, result.Address);
        }

        [Fact]
        public void GetRentalCountsPerPoint_Initially_ReturnsEmptyDictionary()
        {
            // Act
            var result = _repository.GetRentalCountsPerPoint();

            // Assert
            Assert.Empty(result);
        }
    }

    // Тесты для CustomerInMemoryRepository
    public class CustomerInMemoryRepositoryTests
    {
        private readonly CustomerInMemoryRepository _repository;
        private readonly Customer _testCustomer;

        public CustomerInMemoryRepositoryTests()
        {
            _repository = new CustomerInMemoryRepository();
            _testCustomer = new Customer
            {
                Id = 1,
                PassportNumber = "1234567890",
                FullName = "John Doe",
                BirthDate = new DateTime(1980, 1, 1)
            };
        }

        [Fact]
        public void GetAll_Initially_ReturnsEmptyCollection()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_NonExistentId_ReturnsNull()
        {
            // Act
            var result = _repository.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_AddsCustomerToRepository()
        {
            // Act
            _repository.Add(_testCustomer);

            // Assert
            var result = _repository.GetAll().Single();
            Assert.Equal(_testCustomer, result);
        }

        [Fact]
        public void GetByPassport_ExistingPassport_ReturnsCorrectCustomer()
        {
            // Arrange
            _repository.Add(_testCustomer);

            // Act
            var result = _repository.GetByPassport("1234567890");

            // Assert
            Assert.Equal(_testCustomer, result);
        }

        [Fact]
        public void GetByPassport_NonExistentPassport_ReturnsNull()
        {
            // Act
            var result = _repository.GetByPassport("nonexistent");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetByFullName_ExistingNamePart_ReturnsMatchingCustomers()
        {
            // Arrange
            _repository.Add(_testCustomer);
            _repository.Add(new Customer { Id = 2, FullName = "Jane Smith" });

            // Act
            var result = _repository.GetByFullName("john");

            // Assert
            var customer = Assert.Single(result);
            Assert.Equal(_testCustomer, customer);
        }

        [Fact]
        public void Update_ExistingCustomer_UpdatesProperties()
        {
            // Arrange
            _repository.Add(_testCustomer);
            var updatedCustomer = new Customer
            {
                Id = _testCustomer.Id,
                PassportNumber = "0987654321",
                FullName = "John Updated",
                BirthDate = new DateTime(1990, 1, 1)
            };

            // Act
            _repository.Update(updatedCustomer);
            var result = _repository.GetById(_testCustomer.Id);

            // Assert
            Assert.Equal(updatedCustomer.PassportNumber, result.PassportNumber);
            Assert.Equal(updatedCustomer.FullName, result.FullName);
            Assert.Equal(updatedCustomer.BirthDate, result.BirthDate);
        }
    }
}