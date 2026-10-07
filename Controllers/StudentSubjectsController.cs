using HighSchoolSupportSystem.Data;
using HighSchoolSupportSystem.Services;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            var students = _context.Students
                .OrderBy(s => s.FullNames)
                .ToList();

            return View(students);
        }
    }
}