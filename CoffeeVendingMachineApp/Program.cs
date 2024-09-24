using CoffeeVendingMachineApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeVendingMachineApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolve the VendingMachine service
            var vendingMachine = serviceProvider.GetService<ICoffeeService>();
            vendingMachine.DisplayCoffeeMenu();
            vendingMachine.CustomizeCoffee();
        }
    }
}
