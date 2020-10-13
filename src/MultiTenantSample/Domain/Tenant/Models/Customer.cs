using System.ComponentModel.DataAnnotations;

namespace MultiTenantSample.Domain.Tenant.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public bool IsInactive { get; set; }

    }
}
