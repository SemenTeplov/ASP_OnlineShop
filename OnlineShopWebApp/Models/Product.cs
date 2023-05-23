namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCount = 0;
        public int Id { get; }
        public string Name { get; }
        public decimal Coast { get; }
        public string Description { get; }

        public Product(string name, decimal coast, string description) {
            Name = name;
            Coast = coast; 
            Description = description;

            Id = instanceCount;
            instanceCount++;
        }
    }
}
