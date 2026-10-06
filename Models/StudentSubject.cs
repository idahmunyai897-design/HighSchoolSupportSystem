using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class StudentSubject
    {
        [Key]
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public DateTime DateAssigned { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        //Navigation Properties
        [ForeignKey(nameof(Student))]
        public Student Student { get; set; } = null!;
        [ForeignKey(nameof(Subject))]
        public Subject Subject { get; set; } = null!;
    }
}