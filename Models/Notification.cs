using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        
        public int UserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string NotificationType { get; set; } = string.Empty;

        public bool IsRead { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        //Navigation Property
        [ForeignKey(nameof(User))]
        public User User { get; set; } = null!;
    }
}