using CoffeeVendingMachineApp.Entities;
using CoffeeVendingMachineApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private List<Coffee> _predefinedCoffees;
        private List<CoffeeCreamer> _creamerOptions;
        private readonly IExternalCoffeeService _externalCoffeeService;
        public CoffeeRepository(IExternalCoffeeService externalCoffeeService)
        {
            _externalCoffeeService = externalCoffeeService;
            _predefinedCoffees = new List<Coffee>
            {
                new Coffee
                {
                    Name = "Espresso",
                    Price = 1.50,
                    Description = "No milk and no sugar",
                    Characteristics = new List<CoffeeCreamer>()
                    {
                        new CoffeeCreamer
                        {
                            Name = "Milk",
                            Price = 0.30,
                            Quantity = 0.0
                        },
                        new CoffeeCreamer
                        {
                            Name = "Sugar",
                            Price = 0.20,
                            Quantity = 0.0
                        }
                    }
                },
                new Coffee
                {
                    Name = "Latte",
                    Price = 2.50,
                    Description = "Single dose of milk and a pack of sugar",
                    Characteristics = new List<CoffeeCreamer>()
                    {
                        new CoffeeCreamer
                        {
                            Name = "Milk",
                            Price = 0.30,
                            Quantity = 1
                        },
                        new CoffeeCreamer
                        {
                            Name = "Sugar",
                            Price = 0.20,
                            Quantity = 1
                        }
                    }
                },
                new Coffee
                {
                    Name = "Macchiato",
                    Price = 3.00,
                    Description = "Single dose of milk",
                    Characteristics = new List<CoffeeCreamer>()
                    {
                        new CoffeeCreamer
                        {
                            Name = "Milk",
                            Price = 0.30,
                            Quantity = 1
                        }
                    }
                },
                new Coffee
                {
                    Name = "Cappuccino",
                    Price = 2.00,
                    Description = "Double dose of milk and a pack of sugar",
                    Characteristics = new List<CoffeeCreamer>()
                    {
                        new CoffeeCreamer
                        {
                            Name = "Milk",
                            Price = 0.30,
                            Quantity = 2
                        },
                        new CoffeeCreamer
                        {
                            Name = "Sugar",
                            Price = 0.20,
                            Quantity = 1
                        }
                    }
                },
                new Coffee
                {
                    Name = "Americano",
                    Price = 2.00,
                    Description = "No milk and a pack of sugar",
                    Characteristics = new List<CoffeeCreamer>()
                    {
                        new CoffeeCreamer
                        {
                            Name = "Milk",
                            Price = 0.30,
                            Quantity = 0
                        },
                        new CoffeeCreamer
                        {
                            Name = "Sugar",
                            Price = 0.20,
                            Quantity = 1
                        }
                    }
                }
            };
            _creamerOptions = new List<CoffeeCreamer>
            {
                new CoffeeCreamer
                {
                    Name = "Milk",
                    Price = 0.30,
                    Quantity = 0
                },
                new CoffeeCreamer
                {
                    Name = "Sugar",
                    Price = 0.20,
                    Quantity = 0
                },
                new CoffeeCreamer
                {
                    Name = "Chocolate",
                    Price = 0.50,
                    Quantity = 0
                },
                new CoffeeCreamer
                {
                    Name = "Whiskey",
                    Price = 1.00,
                    Quantity = 0
                },
                new CoffeeCreamer
                {
                    Name = "Cream",
                    Price = 0.50,
                    Quantity = 0
                }
            };
        }

        public List<Coffee> GetPredefinedCoffees()
        {
            return _predefinedCoffees;
        }

        public List<CoffeeCreamer> GetCoffeeCreamers()
        {
            return _creamerOptions;
        }

        public List<Coffee> GetExternalCoffees()
        {
           return _externalCoffeeService.GetExternalCoffees();
        }

        public Coffee GetPredefinedCoffeeByName(string coffeeName)
        {
            return _predefinedCoffees.FirstOrDefault(c => c.Name.ToLower() == coffeeName.ToLower());
        }

        public Coffee GetExternalCoffeeByName(string coffeeName)
        {
            var list = GetExternalCoffees();
            return list.FirstOrDefault(c => c.Name.ToLower() == coffeeName.ToLower());
        }

        public CoffeeCreamer GetCreamerByName(Coffee coffee,string creamerName)
        {
            var creamer = coffee.Characteristics
                    .FirstOrDefault(c => c.Name.Equals(creamerName, StringComparison.OrdinalIgnoreCase));
            return creamer;
        }

        public void UpdateCoffeePrice(Coffee coffee, CoffeeCreamer creamer, double newQuantity)
        {
            if (newQuantity < creamer.Quantity)
            {
                coffee.Price -= creamer.Price * (creamer.Quantity - newQuantity);
            }
            else
            {
                coffee.Price += creamer.Price * (newQuantity - creamer.Quantity);
            }
        }

        public void UpdateCreamerQuantity(CoffeeCreamer creamer, double newQuantity)
        {
           creamer.Quantity = newQuantity;
        }
    }
}
