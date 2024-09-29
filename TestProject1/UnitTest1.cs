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
        }

        [Test]
        public async Task TestExternalCoffeesMenu()
        {
            var listExternalCoffees = _externalCoffeeService.GetExternalCoffees();

            // Assert
            Assert.That(listExternalCoffees, Is.Not.Null);
            Assert.That(listExternalCoffees.Count, Is.EqualTo(3));
        }
    }
}