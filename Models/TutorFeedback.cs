using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class TutorFeedback
    {
        [Key]
        public int TutorFeedbackId { get; set; }

        public int SupportSessionId { get; set; }

        public int TutorId { get; set; }

        public int StudentId { get; set; }

        [MaxLength(2000)]
        public string Comments { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        [ForeignKey(nameof(SupportSessionId))]
        public SupportSession SupportSession { get; set; } = null!;

        [ForeignKey(nameof(TutorId))]
        public Tutor Tutor { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}