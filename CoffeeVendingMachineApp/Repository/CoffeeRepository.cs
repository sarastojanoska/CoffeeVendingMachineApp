using CoffeeVendingMachineApp.Data;
using CoffeeVendingMachineApp.Entities;
using CoffeeVendingMachineApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly AppDbContext _context;
        
        public CoffeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Coffee> GetPredefinedCoffees()
        {
            return _context.Coffees.Include(c => c.Characteristics).ToList();
        }

        public Coffee GetPredefinedCoffeeByName(string coffeeName)
        {
            return _context.Coffees.Include(c => c.Characteristics)
                                  .FirstOrDefault(c => c.Name.ToLower() == coffeeName.ToLower());

        }

        public CoffeeCreamer GetCreamerByName(Coffee coffee,string creamerName)
        {
            var creamer = coffee.Characteristics
                    .FirstOrDefault(c => c.Name.Equals(creamerName, StringComparison.OrdinalIgnoreCase));
            return creamer;
        }
    }
}
