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

        //Navigation properties
        [ForeignKey(nameof(Teacher))]
        public Teacher Teacher { get; set; } = null!;
        [ForeignKey(nameof(Student))]
        public Student Student { get; set; } = null!;
    }
}