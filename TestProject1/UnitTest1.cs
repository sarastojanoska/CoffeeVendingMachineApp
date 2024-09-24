using CoffeeVendingMachineApp.Repository;
using CoffeeVendingMachineApp.Services;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private ICoffeeRepository _coffeeRepository;
        private IExternalCoffeeService _externalCoffeeService;

        [SetUp]
        public void Setup()
        {
            _externalCoffeeService = new ExternalCoffeeService();
            _coffeeRepository = new CoffeeRepository(_externalCoffeeService);
        }

        [Test]
        public async Task TestPredefinedCoffeesMenu()
        {
            var listPredefinedCoffees = _coffeeRepository.GetPredefinedCoffees();

            // Assert
            Assert.That(listPredefinedCoffees, Is.Not.Null);
            Assert.That(listPredefinedCoffees.Count, Is.EqualTo(5));
        }

        [Test]
        public async Task TestExternalCoffeesMenu()
        {
            var listExternalCoffees = _coffeeRepository.GetExternalCoffees();

            // Assert
            Assert.That(listExternalCoffees, Is.Not.Null);
            Assert.That(listExternalCoffees.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task TestGetPredefinedCoffeeByName()
        {
            string coffeeName = "Espresso";
            var coffee = _coffeeRepository.GetPredefinedCoffeeByName(coffeeName);

            //Assert
            Assert.That(coffee, Is.Not.Null);
        }
        [Test]
        public async Task TestGetExternalCoffeeByName()
        {
            string coffeeName = "Mocha";
            var coffee = _coffeeRepository.GetExternalCoffeeByName(coffeeName);

            //Assert
            Assert.That(coffee, Is.Not.Null);
        }
        [Test]
        public async Task TestGetCreamerByName()
        {
            string creamerName = "Milk";
            var coffee = _coffeeRepository.GetPredefinedCoffeeByName("Espresso");
            var creamer = _coffeeRepository.GetCreamerByName(coffee, creamerName);
            Assert.That(creamer, Is.Not.Null);
            Assert.That(creamer.Name, Is.EqualTo(creamerName));
            Assert.That(creamer.Quantity, Is.EqualTo(0));
        }
        [Test]
        public async Task TestUpdateCoffeePrice()
        {
            var coffee = _coffeeRepository.GetPredefinedCoffeeByName("Espresso");
            var price = coffee.Price;
            var creamer = _coffeeRepository.GetCreamerByName(coffee, "Milk");
            double newPrice = 2;
            _coffeeRepository.UpdateCoffeePrice(coffee, creamer, newPrice);
            Assert.That(coffee.Price, Is.Not.EqualTo(price));
        }
    }
}