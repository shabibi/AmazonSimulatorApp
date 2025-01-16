namespace AmazonSimulatorApp.Data.DTOs
{
    public class CategoryOutputDto
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public IEnumerable<string> ProductNames { get; set; }
    }
}
