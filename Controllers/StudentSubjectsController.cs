using HighSchoolSupportSystem.Data;
using HighSchoolSupportSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolSupportSystem.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentSubjectService _studentSubjectService;

        public StudentSubjectsController(
            ApplicationDbContext context,
            StudentSubjectService studentSubjectService)
        {
            _context = context;
            _studentSubjectService = studentSubjectService;
        }
        //An action for getting all the learners in the system by thier full names in alphabetical order, and sorting them in a list to be displayed in the view
        public IActionResult Index()
        {
            var students = _context.Students
                .OrderBy(s => s.FullNames)
                .ToList();

            return View(students);
        }

        //Another action when we want to select a particular learner by their Id, also load their grade, and the school
        public IActionResult Select(int id)
        {
            var student = _context.Students
                .Include(s => s.Grade)
                    .ThenInclude(g => g.School)
                .FirstOrDefault(s => s.StudentId == id);//Find the first student whose StudentId matches the id we received

            if (student == null)
            {
                return NotFound();
            }

            var schoolSubjects = _context.SchoolSubjects
                .Include(ss => ss.Subject)
                .Include(ss => ss.SubjectGroup)
                .Where(ss =>
                    ss.SchoolId == student.Grade.SchoolId &&
                    ss.GradeId == student.GradeId &&
                    ss.IsActive)
                .OrderBy(ss => ss.Subject.SubjectName)
                .ToList();

            return View((student, schoolSubjects));
        }
    }
}