using Microsoft.AspNetCore.Mvc;
using School_Management_Project.DTO;
using School_Management_Project.Helper.Unitofwork;

namespace School_Management_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        private readonly IWebHostEnvironment _webHosting;
        public StudentController(Iunitofwork unitofwork, IWebHostEnvironment webHosting)
        {
            _unitofwork = unitofwork;
            _webHosting = webHosting;
        }
        public IActionResult Index(string searchString)
        { try {
                
                    var student = _unitofwork.student.Getall(searchString);
                ViewBag.Student = student;
                    return View();
                
            }
            catch(Exception ex)

            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the students. Please try again.";
                return View("Error");
            }
         
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentPostDTO postDTO)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_webHosting.WebRootPath, "Upload");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                         file.CopyToAsync(fileStream);
                        postDTO.Image = fileName;
                    }
                }

            }
            _unitofwork.student.Create(postDTO);
            _unitofwork.Save();
            return RedirectToAction("Index");
        }


    }
}
