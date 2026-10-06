using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class SubjectGroup
    {
        [Key]
        public int SubjectGroupId { get; set; }

        //[ForeignKey(Grade)]
        public int GradeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string GroupName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsRequired { get; set; }

        public bool IsActive { get; set; } = true;

        //Navigation Properties
        [ForeignKey(nameof(Grade))]
        public Grade Grade { get; set; } = null!;
        [ForeignKey(nameof(SchoolSubjects))]
        public ICollection<SchoolSubject> SchoolSubjects { get; set; } = new List<SchoolSubject>();
    }
}