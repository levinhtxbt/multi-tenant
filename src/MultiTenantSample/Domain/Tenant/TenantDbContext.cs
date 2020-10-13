using Microsoft.EntityFrameworkCore;
using MultiTenantSample.Domain.Tenant.Models;

namespace MultiTenantSample.Domain.Tenant
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }
        
        protected TenantDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<Customer> Customers { get; set; }

    }
}
