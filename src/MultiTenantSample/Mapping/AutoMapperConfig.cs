using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MultiTenantSample.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps("MultiTenantSample"); // Scan configuration mapping by attribute
            });

            return config;
        }
    }
}
