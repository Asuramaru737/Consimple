namespace Consimple_Test_Task.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ItemNo { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public List<Purchase>? Purchases { get; set; } = new List<Purchase>();

        public Product()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
