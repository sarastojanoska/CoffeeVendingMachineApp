using System.ComponentModel.DataAnnotations;

namespace CoffeeVendingMachineApp.Entities
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CoffeeCreamer> Characteristics { get; set; }

    }
}
