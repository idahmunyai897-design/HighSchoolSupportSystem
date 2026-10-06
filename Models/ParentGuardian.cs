using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class ParentGuardian
    {
        [Key]
        public int ParentGuardianId { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullNames { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string RelationshipToStudent { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string AlternativePhoneNumber { get; set; } = string.Empty;

        [MaxLength(250)]
        public string HomeAddress { get; set; } = string.Empty;

        public bool IsPrimaryContact { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Property

        public ICollection<StudentParentGuardian> StudentParentGuardians { get; set; }
            = new List<StudentParentGuardian>();
    }
}