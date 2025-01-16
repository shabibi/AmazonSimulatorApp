using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.DTOs;

namespace AmazonSimulatorApp.Services
{
    public interface IProductService
    {
        void AddProduct(ProductInputDto productDto);
        IEnumerable<ProductOutputDto> GetAllProducts(int pageNumber, int pageSize, string? name = null, decimal? minPrice = null, decimal? maxPrice = null);
        ProductOutputDto GetProductById(int pid);
        ProductOutputDto GetProductByName(string productName);
        void UpdateProduct(int productId, ProductInputDto productDto);
        void RemoveProduct(int ID);
    }
}