using CoffeeVendingMachineApp.Data;
using CoffeeVendingMachineApp.Repository;
using CoffeeVendingMachineApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });
            services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped<IExternalCoffeeService, ExternalCoffeeService>();
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        }
    }
}
