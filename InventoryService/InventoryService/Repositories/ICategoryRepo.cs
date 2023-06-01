using InventoryService.Models;

namespace InventoryService.Repositories
{
    public interface ICategoryRepo
    {
        Task<Category> AddCategory(Category Category);
        Task<Category> UpdateCategory(long Id, string CategoryName);
        Task<bool> DeleteCategory(long Id);
        Task<Category> GetCategoryById(long Id);
        Task<IEnumerable<Category>> GetCategories();
    }
}