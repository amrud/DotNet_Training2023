using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private InventoryContext _db;
        public ProductRepo(InventoryContext db)
        {
            _db = db;
        }

        public async Task<Product> AddProduct(Product Product, long CategoryId)
        {
            var result = await _db.Categories.FirstOrDefaultAsync(c =>
                        c.CategoryId == CategoryId);
            if (result != null)
            {
                Product.Category = result;
            }

            var Result = await _db.Products.AddAsync(Product);
            await _db.SaveChangesAsync();
            return Result.Entity;
        }

        public async Task<bool> DeleteProduct(long Id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(p =>
            p.ProductId == Id);

            if (result != null)
            {
                _db.Products.Remove(result);
                await _db.SaveChangesAsync();

            }
            result = await _db.Products.FirstOrDefaultAsync(p =>
            p.ProductId == Id);

            if (result == null)
            {
                return true;
            }

            else
                return false;

        }

        public async Task<Product> GetProduct(long Id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == Id);
            return result;

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(long Id, long Cost)
        {
            var result = await _db.Products.FirstOrDefaultAsync(p =>
            p.ProductId == Id);

            if (result != null)
            {
                result.ProductDescription.Cost = Cost;
                await _db.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}