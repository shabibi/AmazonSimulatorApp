using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AmazonSimulatorApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;

        }


        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _categoryRepo.GetAllCategories();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving categories: {ex.Message}");
            }
        }


        public Category GetCategoryById(int cid)
        {
            var category = _categoryRepo.GetCategoryById(cid);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {cid} not found.");
            return category;
        }
        public void AddCategory(Category category)
        {
            _categoryRepo.AddCategory(category);
        }

        public void UpdateProduct(Category category)
        {

            var existingcate = _categoryRepo.GetCategoryById(category.CatID);
            if (existingcate == null)
                throw new KeyNotFoundException($"Category with ID {category.CatID} not found.");

            _categoryRepo.UpdateCategory(category);
        }

        public Category GetCategoryByName(string name)
        {

            var category = _categoryRepo.GetCategoryByName(name);
            if (category == null)
                throw new KeyNotFoundException($"Category with Nmae {name} not found.");
            return category;
        }
        public void RemoveCategory(int ID)
        {
            var category = _categoryRepo.GetCategoryById(ID);
            if (category == null)
            {
                throw new Exception("category not found.");
            }

            _categoryRepo.DeleteCategory(ID);
        }

    }
}
