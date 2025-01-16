using AmazonSimulatorApp.Data;
using AmazonSimulatorApp.Data.DTOs;
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


        public IEnumerable<CategoryOutputDto> GetAllCategories()
        {
            try
            {
                var categories = _categoryRepo.GetAllCategories();
                return categories.Select(category => new CategoryOutputDto
                {
                    CatID = category.CatID,
                    Name = category.Name,
                    Count = category.Count,
                    ProductNames = category.Products?.Select(p => p.Name) ?? new List<string>()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving categories: {ex.Message}");
            }
        }


        public CategoryOutputDto GetCategoryById(int cid)
        {
            var category = _categoryRepo.GetCategoryById(cid);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {cid} not found.");
            return new CategoryOutputDto
            {
                CatID = category.CatID,
                Name = category.Name,
                Count = category.Count,
                ProductNames = category.Products?.Select(p => p.Name) ?? new List<string>()
            };
        }
        public void AddCategory(CategoryInputDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Count = categoryDto.Count
            };
            _categoryRepo.AddCategory(category);
        }

        public void UpdateProduct(int categoryId, CategoryInputDto categoryDto)
        {

            var existingCategory = _categoryRepo.GetCategoryById(categoryId);
            if (existingCategory == null)
                throw new KeyNotFoundException($"Category with ID {categoryId} not found.");

            existingCategory.Name = categoryDto.Name;
            existingCategory.Count = categoryDto.Count;

            _categoryRepo.UpdateCategory(existingCategory);
        }

        public CategoryOutputDto GetCategoryByName(string name)
        {

            var category = _categoryRepo.GetCategoryByName(name);
            if (category == null)
                throw new KeyNotFoundException($"Category with Nmae {name} not found.");
            return new CategoryOutputDto
            {
                CatID = category.CatID,
                Name = category.Name,
                Count = category.Count,
                ProductNames = category.Products?.Select(p => p.Name) ?? new List<string>()
            };
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
