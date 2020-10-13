using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSample.Infrastructure
{
    public interface IScopedCache
    {
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserDomainName { get; set; }

        public int TenantId { get; set; }

    }
}
