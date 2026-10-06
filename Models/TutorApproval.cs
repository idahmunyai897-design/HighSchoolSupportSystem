using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class TutorApproval
    {
        [Key]
        public int TutorApprovalId { get; set; }

        public int TutorId { get; set; }

        public int ApprovedByTeacherId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApprovalStatus { get; set; } = string.Empty;

        public DateTime? ApprovalDate { get; set; }

        [MaxLength(1000)]
        public string Comments { get; set; } = string.Empty;

        // Navigation Properties

        [ForeignKey(nameof(TutorId))]
        public Tutor Tutor { get; set; } = null!;

        [ForeignKey(nameof(ApprovedByTeacherId))]
        public Teacher ApprovedByTeacher { get; set; } = null!;
    }
}