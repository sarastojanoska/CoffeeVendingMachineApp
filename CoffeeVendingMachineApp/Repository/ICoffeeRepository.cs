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
        Task<List<Coffee>> GetPredefinedCoffees();
        Task<Coffee> GetPredefinedCoffeeByName(string coffeeName);
        Task<CoffeeCreamer> GetCreamerByName(Coffee coffee, string creamerName);

    }
}
