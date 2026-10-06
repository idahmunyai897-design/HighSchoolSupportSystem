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

            // 5. Create subject groups
            if (!context.SubjectGroups.Any())
            {
                var grade10 = context.Grades
                    .First(g => g.GradeNumber == 10);

                var grade11 = context.Grades
                    .First(g => g.GradeNumber == 11);

                var grade12 = context.Grades
                    .First(g => g.GradeNumber == 12);

                var subjectGroups = new List<SubjectGroup>
                {
                    // Grade 10
                    new SubjectGroup
                    {
                        GradeId = grade10.GradeId,
                        GroupName = "Mathematics Choice",
                        Description = "Learner chooses Mathematics or Technical Mathematics.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade10.GradeId,
                        GroupName = "Science Choice",
                        Description = "Science subject depends on the learner's Mathematics choice.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade10.GradeId,
                        GroupName = "Technical Specialisation",
                        Description = "Learner chooses one technical specialisation.",
                        IsRequired = true,
                        IsActive = true
                    },

                    // Grade 11
                    new SubjectGroup
                    {
                        GradeId = grade11.GradeId,
                        GroupName = "Mathematics Choice",
                        Description = "Learner chooses Mathematics or Technical Mathematics.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade11.GradeId,
                        GroupName = "Science Choice",
                        Description = "Science subject depends on the learner's Mathematics choice.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade11.GradeId,
                        GroupName = "Technical Specialisation",
                        Description = "Learner chooses one technical specialisation.",
                        IsRequired = true,
                        IsActive = true
                    },

                    // Grade 12
                    new SubjectGroup
                    {
                        GradeId = grade12.GradeId,
                        GroupName = "Mathematics Choice",
                        Description = "Learner chooses Mathematics or Technical Mathematics.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade12.GradeId,
                        GroupName = "Science Choice",
                        Description = "Science subject depends on the learner's Mathematics choice.",
                        IsRequired = true,
                        IsActive = true
                    },

                    new SubjectGroup
                    {
                        GradeId = grade12.GradeId,
                        GroupName = "Technical Specialisation",
                        Description = "Learner chooses one technical specialisation.",
                        IsRequired = true,
                        IsActive = true
                    }
                };

                context.SubjectGroups.AddRange(subjectGroups);
                context.SaveChanges();
            }

            // 6. Create school subjects
            if (!context.SchoolSubjects.Any())
            {
                var schoolId = vertexSchool.SchoolId;

                var grades = context.Grades.ToList();
                var subjects = context.Subjects.ToList();
                var subjectGroups = context.SubjectGroups.ToList();

                int GetGradeId(int gradeNumber)
                {
                    return grades.First(g => g.GradeNumber == gradeNumber).GradeId;
                }

                int GetSubjectId(string subjectName)
                {
                    return subjects.First(s => s.SubjectName == subjectName).SubjectId;
                }

                int GetGroupId(int gradeNumber, string groupName)
                {
                    return subjectGroups.First(
                        g => g.Grade.GradeNumber == gradeNumber &&
                             g.GroupName == groupName
                    ).SubjectGroupId;
                }

                var schoolSubjects = new List<SchoolSubject>();

                // -------------------------
                // Grades 8–9
                // -------------------------

                string[] juniorSubjects =
                {
        "English First Additional Language",
        "Tshivenda Home Language",
        "Mathematics",
        "Natural Sciences",
        "History",
        "Geography",
        "Life Orientation",
        "Creative Arts",
        "Technology"
    };

                foreach (var gradeNumber in new[] { 8, 9 })
                {
                    foreach (var subjectName in juniorSubjects)
                    {
                        schoolSubjects.Add(new SchoolSubject
                        {
                            SchoolId = schoolId,
                            GradeId = GetGradeId(gradeNumber),
                            SubjectId = GetSubjectId(subjectName),
                            SubjectGroupId = null,
                            IsCompulsory = true,
                            IsActive = true
                        });
                    }
                }

                // -------------------------
                // Grades 10–12
                // -------------------------

                string[] seniorCompulsorySubjects =
                {
        "English First Additional Language",
        "Tshivenda Home Language",
        "Life Orientation",
        "Engineering Graphics and Design"
    };

                string[] mathematicsChoices =
                {
        "Mathematics",
        "Technical Mathematics"
    };

                string[] scienceChoices =
                {
        "Physical Sciences",
        "Technical Sciences"
    };

                string[] technicalSpecialisations =
                {
        "Civil Technology",
        "Electrical Technology",
        "Mechanical Technology"
    };

                foreach (var gradeNumber in new[] { 10, 11, 12 })
                {
                    // Compulsory subjects
                    foreach (var subjectName in seniorCompulsorySubjects)
                    {
                        schoolSubjects.Add(new SchoolSubject
                        {
                            SchoolId = schoolId,
                            GradeId = GetGradeId(gradeNumber),
                            SubjectId = GetSubjectId(subjectName),
                            SubjectGroupId = null,
                            IsCompulsory = true,
                            IsActive = true
                        });
                    }

                    // Mathematics choice
                    int mathematicsGroupId =
                        GetGroupId(gradeNumber, "Mathematics Choice");

                    foreach (var subjectName in mathematicsChoices)
                    {
                        schoolSubjects.Add(new SchoolSubject
                        {
                            SchoolId = schoolId,
                            GradeId = GetGradeId(gradeNumber),
                            SubjectId = GetSubjectId(subjectName),
                            SubjectGroupId = mathematicsGroupId,
                            IsCompulsory = false,
                            IsActive = true
                        });
                    }

                    // Science choice
                    int scienceGroupId =
                        GetGroupId(gradeNumber, "Science Choice");

                    foreach (var subjectName in scienceChoices)
                    {
                        schoolSubjects.Add(new SchoolSubject
                        {
                            SchoolId = schoolId,
                            GradeId = GetGradeId(gradeNumber),
                            SubjectId = GetSubjectId(subjectName),
                            SubjectGroupId = scienceGroupId,
                            IsCompulsory = false,
                            IsActive = true
                        });
                    }

                    // Technical specialisation
                    int technicalGroupId =
                        GetGroupId(gradeNumber, "Technical Specialisation");

                    foreach (var subjectName in technicalSpecialisations)
                    {
                        schoolSubjects.Add(new SchoolSubject
                        {
                            SchoolId = schoolId,
                            GradeId = GetGradeId(gradeNumber),
                            SubjectId = GetSubjectId(subjectName),
                            SubjectGroupId = technicalGroupId,
                            IsCompulsory = false,
                            IsActive = true
                        });
                    }
                }

                context.SchoolSubjects.AddRange(schoolSubjects);
                context.SaveChanges();
            }
        }
    }
}