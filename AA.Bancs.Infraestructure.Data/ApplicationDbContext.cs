using AA.Bancs.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace AA.Bancs.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Modelos de la base de datos
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
