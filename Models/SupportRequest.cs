using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class SupportRequest
    {
        [Key]
        public int SupportRequestId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(2000)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        [Required]
        [MaxLength(50)]
        public string Priority { get; set; } = "Normal";

        public DateTime? DateCompleted { get; set; }

        //Navigation properties
        [ForeignKey(nameof(Subject))]
        public Student Student { get; set; } = null!;
        [ForeignKey(nameof(Subject))]
        public Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public User CreatedByUser { get; set; } = null!;
        [ForeignKey(nameof(TutorAssignment))]
        public ICollection<TutorAssignment> TutorAssignments { get; set; } = new List<TutorAssignment>();
    }
}