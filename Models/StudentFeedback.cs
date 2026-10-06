using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class StudentFeedback
    {
        [Key]
        public int StudentFeedbackId { get; set; }

        public int SupportSessionId { get; set; }

        public int StudentId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(2000)]
        public string Comments { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        [ForeignKey(nameof(SupportSessionId))]
        public SupportSession SupportSession { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}