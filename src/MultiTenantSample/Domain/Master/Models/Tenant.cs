using System.ComponentModel.DataAnnotations;

namespace MultiTenantSample.Domain.Master.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DatabaseName { get; set; }

        [Required]
        public string DatabaseServer { get; set; }

        public string DatabaseUser { get; set; }

        public string DatabasePassword { get; set; }
    }
}
