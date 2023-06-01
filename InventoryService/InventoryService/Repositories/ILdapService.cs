using InventoryService.Models;

namespace InventoryService.Repositories
{
    public interface ILDapService
    {
        User SearchUser(string userId);
    }
}
