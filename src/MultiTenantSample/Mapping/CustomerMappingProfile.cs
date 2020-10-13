using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiTenantSample.Domain.Tenant.Models;
using MultiTenantSample.DTO.Customer;

namespace MultiTenantSample.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
        
    }
}
