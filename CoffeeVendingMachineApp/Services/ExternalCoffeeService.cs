using CoffeeVendingMachineApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Services
{
    public class ExternalCoffeeService : IExternalCoffeeService
    {
        private const string ExternalCoffeesFilePath = "C:\\Users\\SARA\\source\\repos\\CoffeeVendingMachineApp\\CoffeeVendingMachineApp\\External_coffees.json";
        public List<Coffee> GetExternalCoffees()
        {
            var externalCoffees = new List<Coffee>();
            if (!File.Exists(ExternalCoffeesFilePath))
            {
                return externalCoffees;
            }

            var json = File.ReadAllText(ExternalCoffeesFilePath);
            externalCoffees = JsonConvert.DeserializeObject<List<Coffee>>(json);
            return externalCoffees;
        }
    }
}
