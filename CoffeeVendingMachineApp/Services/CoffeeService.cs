using CoffeeVendingMachineApp.Entities;
using CoffeeVendingMachineApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IExternalCoffeeService _externalCoffeeService;
        public CoffeeService(ICoffeeRepository coffeeRepository
            ,IExternalCoffeeService externalCoffeeService)
        {
            _externalCoffeeService = externalCoffeeService;
            _coffeeRepository = coffeeRepository;
        }

        public void DisplayCoffeeMenu()
        {
            var predefinedCoffees = _coffeeRepository.GetPredefinedCoffees();
            Console.WriteLine("Coffee Menu:");
            foreach (var coffee in predefinedCoffees)
            {
                Console.WriteLine($"{coffee.Name} - ${coffee.Price}");
                Console.WriteLine("Characteristics:" + $"{coffee.Description}");
            }

            var externalCoffees = _externalCoffeeService.GetExternalCoffees();
            if (externalCoffees.Count > 0)
            {
                Console.WriteLine("External Coffee Menu:");
                foreach (var coffee in externalCoffees)
                {
                    Console.WriteLine($"{coffee.Name} - ${coffee.Price}");
                    Console.WriteLine("Characteristics:" + $"{coffee.Description}");
                }
            }
        }

        public void CustomizeCoffee()
        {
            Console.WriteLine("Enter the name of the coffee you want to order:");
            var coffeeName = Console.ReadLine();

            var coffee = _coffeeRepository.GetPredefinedCoffeeByName(coffeeName);
            if (coffee == null)
            {
                var list = _externalCoffeeService.GetExternalCoffees();
                coffee = list.FirstOrDefault(c => c.Name.ToLower() == coffeeName.ToLower());
                if (coffee == null)
                {
                    Console.WriteLine("Invalid coffee name please enter valid name from the provided menu");
                    return;
                }
            }
            Console.WriteLine("These are the creamers in your coffee");
            foreach (var creamer in coffee.Characteristics)
            {
                Console.WriteLine($"{creamer.Name} - {creamer.Quantity}");
            }

            if (AskUserYesNo("Would you like to customize the creamers?"))
            {
                CustomizeCreamers(coffee);
            }
            
            Console.WriteLine("Your ordered coffee is:");
            Console.WriteLine($"{coffee.Name} - ${coffee.Price}");
            DisplayCoffeeCharacteristics(coffee);
        }
        private bool AskUserYesNo(string question)
        {
            Console.WriteLine($"{question} Answer y/n");
            var response = Console.ReadLine()?.Trim().ToLower();

            if (response == "y")
            {
                return true;
            }
            else if (response == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                return AskUserYesNo(question);
            }
        }

        private void CustomizeCreamers(Coffee coffee)
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the creamer you want to customize:");
                var creamerName = Console.ReadLine();
                var creamer = _coffeeRepository.GetCreamerByName(coffee, creamerName);
                if (creamer == null)
                {
                    Console.WriteLine("Invalid creamer name. Please enter a valid name from the provided menu.");
                    continue;
                }

                Console.WriteLine("Enter the quantity of the creamer you want to add. Please enter a valid number:");
                if (!double.TryParse(Console.ReadLine(), out double quantity))
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    continue;
                }

                UpdateCoffeePrice(coffee, creamer, quantity);
                creamer.Quantity = quantity;

                if (!AskUserYesNo("Would you like to customize more creamers?"))
                {
                    break;
                }
            }
        }
        private void UpdateCoffeePrice(Coffee coffee, CoffeeCreamer creamer, double newQuantity)
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

        private void DisplayCoffeeCharacteristics(Coffee coffee)
        {
            foreach (var creamer in coffee.Characteristics)
            {
                Console.WriteLine("Characteristics" + $"{creamer.Name} - {creamer.Quantity}");
            }
        }
    }
}
