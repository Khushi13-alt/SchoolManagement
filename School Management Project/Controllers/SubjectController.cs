using Microsoft.AspNetCore.Mvc;
using School_Management_Project.DTO;
using School_Management_Project.Helper.Unitofwork;

namespace School_Management_Project.Controllers
{
    public class SubjectController : Controller
    {
        private readonly Iunitofwork _unitofwork;
      
        public SubjectController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TeacherSubjectList()
        {
            try
            {
                var subjectsWithTeachers = _unitofwork.subject.GetAllSubjectsWithTeachers();
                return View(subjectsWithTeachers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching subjects: {ex.Message}");
                return View("Error"); 
            }
            
        }
        public IActionResult AddSubject()
        {
            var language=_unitofwork.subject.GetLanguage();
                ViewBag.Languages=language;
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(SubjectPostDTO postDTO)
        {
            
            _unitofwork.subject.Create(postDTO);
            _unitofwork.Save();
            return RedirectToAction("Index");
        }
    }
}
