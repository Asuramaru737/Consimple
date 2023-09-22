using Consimple_Test_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Consimple_Test_Task
{
    public class ProjDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public ProjDbContext(DbContextOptions<ProjDbContext> options) : base(options)
        {
            
        }
    }
}
