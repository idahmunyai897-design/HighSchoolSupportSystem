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

        // Navigation Properties

        [ForeignKey(nameof(TutorId))]
        public Tutor Tutor { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}