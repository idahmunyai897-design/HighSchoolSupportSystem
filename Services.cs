using HighSchoolSupportSystem.Data;
using HighSchoolSupportSystem.Models;

namespace HighSchoolSupportSystem.Services
{
    public class StudentSubjectService
    {
        private readonly ApplicationDbContext _context;

        public StudentSubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (bool IsValid, string Message) ValidateSubjectSelection(
            int gradeId,
            List<int> subjectIds)
        {
            var grade = _context.Grades
                .FirstOrDefault(g => g.GradeId == gradeId);

            if (grade == null)
            {
                return (false, "Grade not found.");
            }

            var subjects = _context.Subjects
                .Where(s => subjectIds.Contains(s.SubjectId))
                .ToList();

            // Prevent duplicate subjects
            if (subjectIds.Count != subjectIds.Distinct().Count())
            {
                return (false, "A subject cannot be selected more than once.");
            }

            // Grade 8–9 rules
            if (grade.GradeNumber == 8 || grade.GradeNumber == 9)
            {
                var requiredJuniorSubjects = new[]
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

                var selectedNames = subjects
                    .Select(s => s.SubjectName)
                    .ToHashSet();

                foreach (var requiredSubject in requiredJuniorSubjects)
                {
                    if (!selectedNames.Contains(requiredSubject))
                    {
                        return (
                            false,
                            $"Grade {grade.GradeNumber} requires {requiredSubject}."
                        );
                    }
                }

                if (subjectIds.Count != 9)
                {
                    return (
                        false,
                        $"Grade {grade.GradeNumber} must have exactly 9 subjects."
                    );
                }

                return (true, "Subject selection is valid.");
            }

            // Grade 10–12 rules
            if (grade.GradeNumber >= 10 && grade.GradeNumber <= 12)
            {
                var selectedNames = subjects
                    .Select(s => s.SubjectName)
                    .ToHashSet();

                // Required subjects
                string[] compulsorySubjects =
                {
                    "English First Additional Language",
                    "Tshivenda Home Language",
                    "Life Orientation",
                    "Engineering Graphics and Design"
                };

                foreach (var requiredSubject in compulsorySubjects)
                {
                    if (!selectedNames.Contains(requiredSubject))
                    {
                        return (
                            false,
                            $"Grade {grade.GradeNumber} requires {requiredSubject}."
                        );
                    }
                }

                // Mathematics choice
                bool hasMathematics =
                    selectedNames.Contains("Mathematics");

                bool hasTechnicalMathematics =
                    selectedNames.Contains("Technical Mathematics");

                if (hasMathematics && hasTechnicalMathematics)
                {
                    return (
                        false,
                        "A learner must choose either Mathematics or Technical Mathematics, not both."
                    );
                }

                if (!hasMathematics && !hasTechnicalMathematics)
                {
                    return (
                        false,
                        "A learner must choose Mathematics or Technical Mathematics."
                    );
                }

                // Science dependency
                bool hasPhysicalSciences =
                    selectedNames.Contains("Physical Sciences");

                bool hasTechnicalSciences =
                    selectedNames.Contains("Technical Sciences");

                if (hasMathematics && !hasPhysicalSciences)
                {
                    return (
                        false,
                        "Learners taking Mathematics must take Physical Sciences."
                    );
                }

                if (hasTechnicalMathematics && !hasTechnicalSciences)
                {
                    return (
                        false,
                        "Learners taking Technical Mathematics must take Technical Sciences."
                    );
                }

                // Prevent wrong science combination
                if (hasMathematics && hasTechnicalSciences)
                {
                    return (
                        false,
                        "Technical Sciences requires Technical Mathematics."
                    );
                }

                if (hasTechnicalMathematics && hasPhysicalSciences)
                {
                    return (
                        false,
                        "Physical Sciences requires Mathematics."
                    );
                }

                // Technical specialisation
                string[] technicalSubjects =
                {
                    "Civil Technology",
                    "Electrical Technology",
                    "Mechanical Technology"
                };

                int technicalCount = technicalSubjects
                    .Count(selectedNames.Contains);

                if (technicalCount != 1)
                {
                    return (
                        false,
                        "A learner must choose exactly one technical specialisation."
                    );
                }

                // Exactly 7 subjects
                if (subjectIds.Count != 7)
                {
                    return (
                        false,
                        "Grade 10–12 learners must have exactly 7 subjects."
                    );
                }

                return (true, "Subject selection is valid.");
            }

            return (false, "Invalid grade.");
        }
    }
}