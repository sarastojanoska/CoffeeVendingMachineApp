using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeVendingMachineApp.Entities
{
    public class CoffeeCreamer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public int CoffeeId { get; set; }
        [ForeignKey("CoffeeId")]
        public virtual Coffee Coffee{ get; set; }
    }
}
