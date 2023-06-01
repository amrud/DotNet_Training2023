using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Contexts
{
    public class InventoryIdentityContext : IdentityDbContext<IdentityUser>
    {
        public InventoryIdentityContext(DbContextOptions<InventoryIdentityContext> opt) : base(opt)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
