using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int SupportSessionId { get; set; }

        public bool StudentPresent { get; set; }

        public bool TutorPresent { get; set; }

        [Required]
        [MaxLength(50)]
        public string AttendanceStatus { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Notes { get; set; } = string.Empty;

        //Navigation Property
        [ForeignKey(nameof(SupportSession))]
        public SupportSession SupportSession { get; set; } = null!;
    }
}
