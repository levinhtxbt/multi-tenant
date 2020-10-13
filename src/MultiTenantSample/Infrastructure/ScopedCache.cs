namespace MultiTenantSample.Infrastructure
{
    public class ScopedCache : IScopedCache
    {
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserDomainName { get; set; }
        public int TenantId { get; set; }
    }
}
