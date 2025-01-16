
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int Cid);
        Category GetCategoryByName(string CateName);
        void UpdateCategory(Category category);
    }
}