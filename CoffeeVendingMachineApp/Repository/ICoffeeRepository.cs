using CoffeeVendingMachineApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Repository
{
    public interface ICoffeeRepository
    {
        List<Coffee> GetPredefinedCoffees();
        List<CoffeeCreamer> GetCoffeeCreamers();
    }
}
