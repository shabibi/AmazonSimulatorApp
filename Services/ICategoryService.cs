using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        Category GetCategoryById(int cid);
        Category GetCategoryByName(string name);
        void RemoveCategory(int ID);
        void UpdateProduct(Category category);
    }
}