namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCount = 0;
        public int Id { get; }
        public string Name { get; }
        public decimal Coast { get; }
        public string Description { get; }
        public string ImagePath { get; }

        public Product(string name, decimal coast, string description, string imagePath) {
            Name = name;
            Coast = coast; 
            Description = description;
            ImagePath = imagePath;

            Id = instanceCount;
            instanceCount++;
        }
    }
}
