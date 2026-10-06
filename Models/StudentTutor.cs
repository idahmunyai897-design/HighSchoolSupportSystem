using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class StudentTutor
    {
        [Key]
        public int StudentTutorId { get; set; }

        public int TutorId { get; set; }

        public int StudentId { get; set; }

        //Navigation Peoperty
        [ForeignKey(nameof(Tutor))]
        public Tutor Tutor { get; set; } = null!;
        [ForeignKey(nameof(Student))]
        public Student Student { get; set; } = null!;
    }
}