using CoffeeVendingMachineApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using CoffeeVendingMachineApp.Data;
using CoffeeVendingMachineApp.Seed;
using Microsoft.Extensions.Logging;
namespace CoffeeVendingMachineApp
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            var startup = new Startup(Configuration);
            startup.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogInformation("Using In-Memory Database");

            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                SeedPredefinedCoffees.Seed(context);
            }
            var vendingMachine = serviceProvider.GetService<ICoffeeService>();
            vendingMachine.DisplayCoffeeMenu();
            vendingMachine.CustomizeCoffee();
        }
    }
}

