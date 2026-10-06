using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

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

        [Required]
        [MaxLength(50)]
        public string EmployeeNumber { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Position { get; set; } = string.Empty;

        public DateTime DateJoined { get; set; }

        public bool IsActive { get; set; } = true;

        //Navigation properties
        [ForeignKey(nameof(TeacherStudent))]
        public ICollection<TeacherStudent> TeacherStudents { get; set; } = new List<TeacherStudent>();
        [ForeignKey(nameof(TutorApproval))]
        public ICollection<TutorApproval> TutorApprovals { get; set; } = new List<TutorApproval>();
        [ForeignKey(nameof(TutorAssignment))]
        public ICollection<TutorAssignment> TutorAssignments { get; set; } = new List<TutorAssignment>();
    }
}