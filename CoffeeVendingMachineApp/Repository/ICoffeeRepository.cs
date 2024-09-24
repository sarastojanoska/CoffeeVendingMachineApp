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
        List<Coffee> GetExternalCoffees();
        Coffee GetPredefinedCoffeeByName(string coffeeName);
        Coffee GetExternalCoffeeByName(string coffeeName);
        CoffeeCreamer GetCreamerByName(Coffee coffee, string creamerName);
        void UpdateCoffeePrice(Coffee coffee, CoffeeCreamer creamer, double newQuantity);
        void UpdateCreamerQuantity(CoffeeCreamer creamer, double newQuantity);
    }
}
