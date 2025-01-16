
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int pid);
        Product GetProductByName(string productName);
        void UpdateProduct(Product product);
    }
}