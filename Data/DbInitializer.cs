using HighSchoolSupportSystem.Models;

namespace HighSchoolSupportSystem.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // 1. Create the school
            if (!context.Schools.Any())
            {
                var school = new School
                {
                    SchoolName = "Vertex Technical High School",
                    SchoolCode = "VTHS001",
                    Address = "123 Technical Road",
                    City = "Johannesburg",
                    Province = "Gauteng",
                    PostalCode = "2000",
                    PhoneNumber = "0110000000",
                    Email = "info@vertextechnicalhighschool.co.za",
                    IsActive = true
                };

                context.Schools.Add(school);
                context.SaveChanges();
            }

            // 2. Get the school
            var vertexSchool = context.Schools
                .First(s => s.SchoolCode == "VTHS001");

            // 3. Create Grades 8–12
            if (!context.Grades.Any())
            {
                var grades = new List<Grade>
                {
                    new Grade
                    {
                        GradeNumber = 8,
                        GradeName = "Grade 8",
                        SchoolId = vertexSchool.SchoolId,
                        IsActive = true
                    },

                    new Grade
                    {
                        GradeNumber = 9,
                        GradeName = "Grade 9",
                        SchoolId = vertexSchool.SchoolId,
                        IsActive = true
                    },

                    new Grade
                    {
                        GradeNumber = 10,
                        GradeName = "Grade 10",
                        SchoolId = vertexSchool.SchoolId,
                        IsActive = true
                    },

                    new Grade
                    {
                        GradeNumber = 11,
                        GradeName = "Grade 11",
                        SchoolId = vertexSchool.SchoolId,
                        IsActive = true
                    },

                    new Grade
                    {
                        GradeNumber = 12,
                        GradeName = "Grade 12",
                        SchoolId = vertexSchool.SchoolId,
                        IsActive = true
                    }
                };

                context.Grades.AddRange(grades);
                context.SaveChanges();
            }

            // 4. Create subjects
            if (!context.Subjects.Any())
            {
                var subjects = new List<Subject>
            {
                // Grades 8–9
                new Subject
                {
                    SubjectName = "English First Additional Language",
                    Description = "English First Additional Language",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Tshivenda Home Language",
                    Description = "Tshivenda Home Language",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Mathematics",
                    Description = "Mathematics",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Natural Sciences",
                    Description = "Natural Sciences",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "History",
                    Description = "History",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Geography",
                    Description = "Geography",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Life Orientation",
                    Description = "Life Orientation",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Creative Arts",
                    Description = "Creative Arts",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Technology",
                    Description = "Technology",
                    IsActive = true
                },

                // Grades 10–12
                new Subject
                {
                    SubjectName = "Engineering Graphics and Design",
                    Description = "Engineering Graphics and Design",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Technical Mathematics",
                    Description = "Technical Mathematics",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Physical Sciences",
                    Description = "Physical Sciences",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Technical Sciences",
                    Description = "Technical Sciences",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Civil Technology",
                    Description = "Civil Technology",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Electrical Technology",
                    Description = "Electrical Technology",
                    IsActive = true
                },

                new Subject
                {
                    SubjectName = "Mechanical Technology",
                    Description = "Mechanical Technology",
                    IsActive = true
                }
            };

                context.Subjects.AddRange(subjects);
                context.SaveChanges();
            }
        }
    }
}