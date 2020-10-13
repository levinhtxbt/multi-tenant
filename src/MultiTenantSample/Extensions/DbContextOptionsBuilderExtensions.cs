using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MultiTenantSample.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseSerilog(this DbContextOptionsBuilder optionsBuilder, 
            ILoggerFactory loggerFactory, 
            bool throwOnQueryWarnings = false)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Log(RelationalEventId.TransactionError);

                if (!throwOnQueryWarnings)
                {
                    //warnings.Throw(RelationalEventId.QueryClientEvaluationWarning);
                    warnings.Throw(RelationalEventId.QueryPossibleExceptionWithAggregateOperatorWarning);
                    warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
                }
                else
                {
                    //warnings.Log(RelationalEventId.QueryClientEvaluationWarning);
                    warnings.Log(RelationalEventId.QueryPossibleExceptionWithAggregateOperatorWarning);
                    warnings.Log(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
                }
            });

            return optionsBuilder;
        }
    }
}
