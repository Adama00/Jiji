using JIJI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JIJI_API.Data
{
    public class JijiDbContext : DbContext
    {
        public JijiDbContext(DbContextOptions<JijiDbContext> options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}
