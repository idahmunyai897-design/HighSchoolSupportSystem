using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class TutorSubject
    {
        [Key]
        public int TutorSubjectId { get; set; }

        public int TutorId { get; set; }

        public int SubjectId { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(Tutor))]
        public Tutor Tutor { get; set; } = null!;
        [ForeignKey(nameof(Subject))]
        public Subject Subject { get; set; } = null!;
    }
}