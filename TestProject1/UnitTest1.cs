using CoffeeVendingMachineApp.Data;
using CoffeeVendingMachineApp.Repository;
using CoffeeVendingMachineApp.Seed;
using CoffeeVendingMachineApp.Services;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private AppDbContext _context;
        private ICoffeeRepository _coffeeRepository;
        private IExternalCoffeeService _externalCoffeeService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestCoffeeDatabase")
            .Options;

            _context = new AppDbContext(options);

            // Seed the in-memory database
            SeedPredefinedCoffees.Seed(_context);
            _externalCoffeeService = new ExternalCoffeeService();
            _coffeeRepository = new CoffeeRepository(_context);
        }

        [Test]
        public async Task TestPredefinedCoffeesMenu()
        {
            var listCoffees = await _coffeeRepository.GetPredefinedCoffees();

            // Assert
            Assert.That(listCoffees, Is.Not.Null);
            Assert.That(listCoffees.Count, Is.EqualTo(5));
        }

        [Test]
        public async Task TestExternalCoffeesMenu()
        {
            var listExternalCoffees = await _externalCoffeeService.GetExternalCoffees();

            // Assert
            Assert.That(listExternalCoffees, Is.Not.Null);
            Assert.That(listExternalCoffees.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task TestGetPredefinedCoffeeByName()
        {
            var coffee = await _coffeeRepository.GetPredefinedCoffeeByName("Espresso");

            // Assert
            Assert.That(coffee, Is.Not.Null);
            Assert.That(coffee.Name, Is.EqualTo("Espresso"));
        }

        [Test]
        public async Task TestGetCreamerByName()
        {
            var coffee = await _coffeeRepository.GetPredefinedCoffeeByName("Espresso");
            var creamer = await _coffeeRepository.GetCreamerByName(coffee, "Milk");

            // Assert
            Assert.That(creamer, Is.Not.Null);
            Assert.That(creamer.Name, Is.EqualTo("Milk"));
        }
    }
}