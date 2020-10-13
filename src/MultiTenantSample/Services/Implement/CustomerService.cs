using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MultiTenantSample.Domain;
using MultiTenantSample.Domain.Tenant;
using MultiTenantSample.DTO.Customer;
using MultiTenantSample.Infrastructure;

namespace MultiTenantSample.Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IScopedCache _scopedCache;
        private readonly IMapper _mapper;
        private readonly TenantDbContext _tenantDbContext;
        public CustomerService(
            IDbContextFactory<TenantDbContext, int> tenantDbContextFactory, 
            IScopedCache scopedCache, 
            IMapper mapper)
        {
            _scopedCache = scopedCache;
            _mapper = mapper;
            _tenantDbContext = tenantDbContextFactory.Create(_scopedCache.TenantId);
        }

        public async Task<List<CustomerResponse>> GetListAsync()
        {
            return await _tenantDbContext.Customers
                .ProjectTo<CustomerResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
