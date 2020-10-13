using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantSample.DTO.Customer;

namespace MultiTenantSample.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetListAsync();

    }
}
