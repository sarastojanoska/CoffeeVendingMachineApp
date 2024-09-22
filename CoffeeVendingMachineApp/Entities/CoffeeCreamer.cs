using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeVendingMachineApp.Entities
{
    public class CoffeeCreamer
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

    }
}
