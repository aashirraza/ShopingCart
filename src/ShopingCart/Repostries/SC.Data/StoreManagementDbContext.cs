using Microsoft.EntityFrameworkCore;
using SC.Data.Model;

namespace SC.Data
{
    public class StoreManagementDbContext : DbContext
    {
        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options) : base(options)
        {

        }
        public DbSet<product> Products { get; set; }
    }
}