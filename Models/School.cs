using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HighSchoolSupportSystem.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }

        [Required]
        [MaxLength(200)]
        public string SchoolName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string SchoolCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Province { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        //Navigation Properties
        [ForeignKey(nameof(Grade))]
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        [ForeignKey(nameof(SchoolSubject))]
        public ICollection<SchoolSubject> SchoolSubjects { get; set; } = new List<SchoolSubject>();
    }
}