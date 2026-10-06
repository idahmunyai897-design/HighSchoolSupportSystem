using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(150)]
        public string SubjectName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation Properties

        public ICollection<SchoolSubject> SchoolSubjects { get; set; }
            = new List<SchoolSubject>();

        public ICollection<StudentSubject> StudentSubjects { get; set; }
            = new List<StudentSubject>();

        public ICollection<TutorSubject> TutorSubjects { get; set; }
            = new List<TutorSubject>();
    }
}