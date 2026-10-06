using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Range(8, 12)]
        public int GradeNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string GradeName { get; set; } = string.Empty;

        public int SchoolId { get; set; }

        public bool IsActive { get; set; } = true;

        //Navigation Property
        [ForeignKey(nameof(School))]
        public School School { get; set; } = null!;
        [ForeignKey(nameof(SchoolSubject))]
        public ICollection<SchoolSubject> SchoolSubjects { get; set; } = new List<SchoolSubject>();
        [ForeignKey(nameof(Students))]
        public ICollection<Student> Students { get; set; } = new List<Student>();
        [ForeignKey(nameof(SubjectGroups))]
        public ICollection<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
    }
}