namespace HighSchoolSupportSystem.Models
#nullable
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FullNames { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public int GradeId { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string HomeAddress { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}