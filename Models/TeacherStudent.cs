using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class TeacherStudent
    {
        [Key]
        public int TeacherStudentId { get; set; }

        public int TeacherId { get; set; }

        public int StudentId { get; set; }

        // Navigation Properties

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}