using AmazonSimulatorApp.Data.Repositories;
using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.DTOs;

namespace AmazonSimulatorApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }


        public IEnumerable<ProductOutputDto> GetAllProducts(int pageNumber, int pageSize, string? name = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            // Base query
            var query = _productRepo.GetAllProducts();

            // Apply filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductOutputDto
            {
            PID = p.PID,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            Image = p.Image,
            Stock = p.Stock,
            SellerId = p.Seller.SID, // Include seller 
            CategoryName = p.Category?.Name // Include category name if available
             })
               .ToList();

        }
        public ProductOutputDto GetProductById(int pid)
        {
            var product = _productRepo.GetProductById(pid);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {pid} not found.");
            return new ProductOutputDto
            {
                PID = product.PID,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                Stock = product.Stock,
                SellerId = product.Seller.SID, // Include seller 
                CategoryName = product.Category?.Name
            };
        }

        public void AddProduct(ProductInputDto productDto)
        {
            var product = new Product
            {
                SID = productDto.SID,
                CatID = productDto.CatID,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Image = productDto.Image,
                Stock = productDto.Stock
            };

            _productRepo.AddProduct(product);
        }

        public void UpdateProduct(int productId, ProductInputDto productDto)
        {

            var existingProduct = _productRepo.GetProductById(productId);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            existingProduct.SID = productDto.SID;
            existingProduct.CatID = productDto.CatID;
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Description = productDto.Description;
            existingProduct.Image = productDto.Image;
            existingProduct.Stock = productDto.Stock;

            _productRepo.UpdateProduct(existingProduct);
        }

        public ProductOutputDto GetProductByName(string productName)
        {
            var product = _productRepo.GetProductByName(productName);
            if (product == null)
                throw new KeyNotFoundException($"Product with Nmae {productName} not found.");
            return new ProductOutputDto
            {
                PID = product.PID,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                Stock = product.Stock,
                SellerId = product.Seller.SID, // Include seller 
                CategoryName = product.Category?.Name // Include Category Name if available
            };
        }
            public void RemoveProduct(int ID)
        {
            var product = _productRepo.GetProductById(ID);
            if (product == null)
            {
                throw new Exception("product not found.");
            }

            _productRepo.DeleteProduct(ID);
        }


    }
}
