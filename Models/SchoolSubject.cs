using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class SchoolSubject
    {
        [Key]
        public int SchoolSubjectId { get; set; }

        public int SchoolId { get; set; }

        public int GradeId { get; set; }

        public int SubjectId { get; set; }

        // Optional because compulsory subjects do not need a choice group.
        public int? SubjectGroupId { get; set; }

        public bool IsCompulsory { get; set; }

        public bool IsActive { get; set; } = true;

        //Navigation Property
        public School School { get; set; } = null!;
        [ForeignKey(nameof(Grade))]
        public Grade Grade { get; set; } = null!;
        [ForeignKey(nameof(Subject))]
        public Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(SubjectGroup))]
        public SubjectGroup SubjectGroup { get; set; }
    }
}