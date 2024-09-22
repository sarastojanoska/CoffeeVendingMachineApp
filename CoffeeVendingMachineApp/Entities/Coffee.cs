namespace CoffeeVendingMachineApp.Entities
{
    public class Coffee
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<CoffeeCreamer> Characteristics { get; set; }

    }
}
