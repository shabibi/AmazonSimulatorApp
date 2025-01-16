namespace AmazonSimulatorApp.Data.DTOs
{
    public class ProductInputDto
    {
        public int SID { get; set; } // Foreign Key for Seller
        public int CatID { get; set; } // Foreign Key for Category
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; } // Added stock property
    }
}
