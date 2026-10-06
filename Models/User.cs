using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //Navigation Properties
        [ForeignKey(nameof(SupportRequestsCreated))]
        public ICollection<SupportRequest> SupportRequestsCreated { get; set; } = new List<SupportRequest>();
        [ForeignKey(nameof(Notification)]
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        //public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}