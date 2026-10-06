using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolSupportSystem.Models
{
    public class SupportSession
    {
        [Key]
        public int SupportSessionId { get; set; }

        public int TutorAssignmentId { get; set; }

        public DateOnly SessionDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [MaxLength(250)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string SessionStatus { get; set; } = "Scheduled";

        [MaxLength(2000)]
        public string Notes { get; set; } = string.Empty;

        // Navigation Properties

        [ForeignKey(nameof(TutorAssignmentId))]
        public TutorAssignment TutorAssignment { get; set; } = null!;

        public Attendance? Attendance { get; set; }

        public StudentFeedback? StudentFeedback { get; set; }

        public TutorFeedback? TutorFeedback { get; set; }
    }
}