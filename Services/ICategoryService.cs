using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.DTOs;

namespace AmazonSimulatorApp.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryOutputDto> GetAllCategories();
        void AddCategory(CategoryInputDto categoryDto);
        CategoryOutputDto GetCategoryById(int cid);


        CategoryOutputDto GetCategoryByName(string name);
        void RemoveCategory(int ID);
        void UpdateProduct(int categoryId, CategoryInputDto categoryDto);
    }
}