using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullNames { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gender { get; set; } = string.Empty;

        public int GradeId { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(250)]
        public string HomeAddress { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Province { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        [ForeignKey(nameof(GradeId))]
        public Grade Grade { get; set; } = null!;

        public ICollection<StudentSubject> StudentSubjects { get; set; }
            = new List<StudentSubject>();

        public ICollection<StudentParentGuardian> StudentParentGuardians { get; set; }
            = new List<StudentParentGuardian>();

        public ICollection<TeacherStudent> TeacherStudents { get; set; }
            = new List<TeacherStudent>();

        public ICollection<StudentTutor> StudentTutors { get; set; }
            = new List<StudentTutor>();

        public ICollection<SupportRequest> SupportRequests { get; set; }
            = new List<SupportRequest>();

        public ICollection<StudentFeedback> StudentFeedbacks { get; set; }
            = new List<StudentFeedback>();
    }
}