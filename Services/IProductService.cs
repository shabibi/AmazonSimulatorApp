using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize, string? name = null, decimal? minPrice = null, decimal? maxPrice = null);
        Product GetProductById(int pid);
        Product GetProductByName(string productName);
        void UpdateProduct(Product product);
    }
}