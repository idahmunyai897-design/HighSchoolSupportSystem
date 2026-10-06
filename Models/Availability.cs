using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolSupportSystem.Models
{
    public class Availability
    {
        [Key]
        public int AvailabilityId { get; set; }

        public int TutorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string DayOfWeek { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string AvailabilityType { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation Property

        [ForeignKey(nameof(TutorId))]
        public Tutor Tutor { get; set; } = null!;
    }
}