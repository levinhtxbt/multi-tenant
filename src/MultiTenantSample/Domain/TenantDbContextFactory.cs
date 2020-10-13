
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MultiTenantSample.Domain.Master;
using MultiTenantSample.Domain.Tenant;

namespace MultiTenantSample.Domain
{
    public interface IDbContextFactory<TContext, TKey> where TContext :DbContext
    {
        TContext Create(TKey key);
    }

    public class TenantDbContextFactory : IDbContextFactory<TenantDbContext, int>
    {
        private readonly MasterDbContext _masterDbContext;

        public TenantDbContextFactory(MasterDbContext masterDbContext)
        {
            _masterDbContext = masterDbContext;
        }

        public TenantDbContext Create(int tenantId)
        {
            var connectionString = GetConnectionString(tenantId);
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TenantDbContext(optionsBuilder.Options);
        }

        private string GetConnectionString(int tenantId)
        {
            var tenant = _masterDbContext.Tenants
                .FirstOrDefault(x => x.Id == tenantId);
            if (tenant == null)
                throw new NullReferenceException("Can not create tenant db");

            return $"Data Source={tenant.DatabaseServer};Initial Catalog={tenant.DatabaseName};Integrated Security=True";
        }

    }


}
