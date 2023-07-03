using AA.Bancs.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AA.Bancs.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        // Modelos de la base de datos
        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}