using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TutorType { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string FullNames { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        public StudentTutor StudentTutor { get; set; }

        public ExternalTutor ExternalTutor { get; set; }

        public ICollection<TutorSubject> TutorSubjects { get; set; }
            = new List<TutorSubject>();

        public ICollection<Availability> Availabilities { get; set; }
            = new List<Availability>();

        public ICollection<TutorApproval> TutorApprovals { get; set; }
            = new List<TutorApproval>();

        public ICollection<TutorAssignment> TutorAssignments { get; set; }
            = new List<TutorAssignment>();

        public ICollection<TutorFeedback> TutorFeedbacks { get; set; }
            = new List<TutorFeedback>();
    }
}