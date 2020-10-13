using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MultiTenantSample.Extensions
{
    public static  class HostBuilderExtensions
    {
        public static void ConfigureLogging(HostBuilderContext hostBuilderContext, ILoggingBuilder logging)
        {
            var configuration = hostBuilderContext.Configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Environment", hostBuilderContext.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("ApplicationName", hostBuilderContext.HostingEnvironment.ApplicationName)
                .CreateLogger();
            
            logging.ClearProviders();
            logging.AddSerilog(); 
        }
    }
}
