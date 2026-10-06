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

        //Navigation Properties
        [ForeignKey(nameof(SupportSession))]
        public SupportSession SupportSession { get; set; } = null!;
        [ForeignKey(nameof(Tutor))]
        public Tutor Tutor { get; set; } = null!;
        [ForeignKey(nameof(Student))]
        public Student Student { get; set; } = null!;
    }
}