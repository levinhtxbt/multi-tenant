using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenantSample.Domain.Master.Models;

namespace MultiTenantSample.Domain.Master
{
    public class MasterDbContext : IdentityDbContext<IdentityUser>
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }
        
        protected MasterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Tenant> Tenants { get; set; }  

    }
}
