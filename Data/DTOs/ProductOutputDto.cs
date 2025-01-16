namespace AmazonSimulatorApp.Data.DTOs
{
    public class ProductOutputDto
    {
        public int PID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; } // Stock property
        public int SellerId { get; set; } // Related seller data
        public string CategoryName { get; set; } // Related category data
    }
}
