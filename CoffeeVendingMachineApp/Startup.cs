using CoffeeVendingMachineApp.Repository;
using CoffeeVendingMachineApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped<IExternalCoffeeService, ExternalCoffeeService>();
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        }
    }
}
