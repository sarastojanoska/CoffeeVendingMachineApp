using CoffeeVendingMachineApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Services
{
    public class CoffeeService : ICoffeeService
    {
        private List<Coffee> _predefinedCoffees;
        private List<CoffeeCreamer> _creamerOptions;
        private IExternalCoffeeService _externalCoffeeService;

        public CoffeeService(IExternalCoffeeService externalCoffeeService)
        {
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
                }
            };
            _externalCoffeeService = externalCoffeeService;
        }

        public void DisplayCoffeeMenu()
        {
            Console.WriteLine("Coffee Menu:");
            foreach (var coffee in _predefinedCoffees)
            {
                Console.WriteLine($"{coffee.Name} - ${coffee.Price}");
                Console.WriteLine("Characteristics:" + $"{coffee.Description}");
            }

            Console.WriteLine("External Coffee Menu:");
            var externalCoffees = _externalCoffeeService.GetExternalCoffees();
            if(externalCoffees.Count > 0)
            {
                foreach (var coffee in externalCoffees)
                {
                    Console.WriteLine($"{coffee.Name} - ${coffee.Price}");
                    Console.WriteLine("Characteristics:" + $"{coffee.Description}");
                }
            }
        }
    }
}
