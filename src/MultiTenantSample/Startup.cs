using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MultiTenantSample.Domain;
using MultiTenantSample.Domain.Master;
using MultiTenantSample.Domain.Tenant;
using MultiTenantSample.Extensions;
using MultiTenantSample.Infrastructure;
using MultiTenantSample.Mapping;
using MultiTenantSample.Services;
using MultiTenantSample.Services.Implement;

namespace MultiTenantSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.ConfigureDbContext<MasterDbContext>(Configuration);
            services.ConfigureDbContext<TenantDbContext>(Configuration, "Tenant");
            
            services.AddScoped<IDbContextFactory<TenantDbContext, int>, TenantDbContextFactory>();
            services.AddScoped<IScopedCache, ScopedCache>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
