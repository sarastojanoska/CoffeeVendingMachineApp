using CoffeeVendingMachineApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Services
{
    public interface ICoffeeService
    {
        Task DisplayCoffeeMenu();
        Task CustomizeCoffee();
    }
}
