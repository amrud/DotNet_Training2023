using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private InventoryContext _db;

        public CategoryRepo(InventoryContext db)
        {
            _db = db;
        }

        public async Task<Category> AddCategory(Category Category)
        {
            //insert query
            //Id will be generated
            var Result = await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return Result.Entity;
        }

        public async Task<bool> DeleteCategory(long Id)
        {
            var result = await _db.Categories.FirstOrDefaultAsync
               (c => c.CategoryId == Id);
            if (result != null)
            {
                _db.Categories.Remove(result);
                _db.SaveChanges();
            }
            result = await _db.Categories.FirstOrDefaultAsync
               (c => c.CategoryId == Id);
            if (result == null)
                return true;
            else
                return false;

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            //select * from category;
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(long Id)
        {
            //select * from category where categoryId=Id
            var result = await _db.Categories.FirstOrDefaultAsync
                 (c => c.CategoryId == Id);

            return result;
        }

        public async Task<Category> UpdateCategory(long Id, string CategoryName)
        {
            var result = await _db.Categories.FirstOrDefaultAsync
                (c => c.CategoryId == Id);
            if (result != null)
            {
                result.CategoryName = CategoryName;
                await _db.SaveChangesAsync();

            }
            return result;

        }
    }
}