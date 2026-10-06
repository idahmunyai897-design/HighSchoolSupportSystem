using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HighSchoolSupportSystem.Models
{
    public class StudentParentGuardian
    {
        [Key]
        public int StudentParentGuardianId { get; set; }

        public int StudentId { get; set; }

        public int ParentGuardianId { get; set; }

        // Navigation Properties

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(ParentGuardianId))]
        public ParentGuardian ParentGuardian { get; set; } = null!;
    }
}