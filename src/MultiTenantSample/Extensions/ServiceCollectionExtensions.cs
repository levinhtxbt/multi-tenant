using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MultiTenantSample.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext<DBContext>(this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName = null) where DBContext : DbContext
        {
            string defaultConnectionStr = configuration.GetConnectionString(connectionStringName ?? "DefaultConnection");

            services.AddDbContextPool<DBContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(defaultConnectionStr);
                // Enable logging
                var provider = services.BuildServiceProvider();
                var loggerFactory = provider.GetService<ILoggerFactory>();
                options.UseSerilog(loggerFactory, true);
            });
        }
    }
}
