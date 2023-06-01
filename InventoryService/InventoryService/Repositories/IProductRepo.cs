using InventoryService.Models;

namespace InventoryService.Repositories
{
    public interface IProductRepo
    {
        Task<Product> AddProduct(Product Product, long CatalogId);
        Task<Product> UpdateProduct(long Id, long Cost);
        Task<bool> DeleteProduct(long Id);
        Task<Product> GetProduct(long Id);
        Task<IEnumerable<Product>> GetProducts();
    }
}