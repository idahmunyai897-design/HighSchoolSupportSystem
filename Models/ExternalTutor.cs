using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class ExternalTutor
    {
        [Key]
        public int ExternalTutorId { get; set; }

        public int TutorId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Institution { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Experience { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string BackgroundInformation { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string VerificationStatus { get; set; } = string.Empty;

        //Navigation Property
        [ForeignKey(nameof(Tutor))]
        public Tutor Tutor { get; set; } = null!;
    }
}