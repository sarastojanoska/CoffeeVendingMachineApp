using CoffeeVendingMachineApp.Data;
using CoffeeVendingMachineApp.Entities;

namespace CoffeeVendingMachineApp.Seed
{
    public class SeedPredefinedCoffees
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Coffees.Any())
            {
                return;
            }
            
            var predefinedCoffees = new List<Coffee>
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

            context.Coffees.AddRange(predefinedCoffees);
            context.SaveChanges();
        }
    }
}