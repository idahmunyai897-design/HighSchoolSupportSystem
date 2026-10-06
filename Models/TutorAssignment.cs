using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class TutorAssignment
    {
        [Key]
        public int TutorAssignmentId { get; set; }

        public int SupportRequestId { get; set; }

        public int TutorId { get; set; }

        public int AssignedByTeacherId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Assigned";

        [MaxLength(2000)]
        public string Notes { get; set; } = string.Empty;

        // Navigation Properties

        [ForeignKey(nameof(SupportRequestId))]
        public SupportRequest SupportRequest { get; set; } = null!;

        [ForeignKey(nameof(TutorId))]
        public Tutor Tutor { get; set; } = null!;

        [ForeignKey(nameof(AssignedByTeacherId))]
        public Teacher AssignedByTeacher { get; set; } = null!;

        public ICollection<SupportSession> SupportSessions { get; set; }
            = new List<SupportSession>();
    }
}