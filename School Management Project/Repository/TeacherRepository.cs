using Microsoft.EntityFrameworkCore;
using School_Management_Project.DTO;
using School_Management_Project.Models;

namespace School_Management_Project.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DbschoolContext _context;
        public TeacherRepository(DbschoolContext dbschoolContext)
        {
            _context = dbschoolContext;
        }
        public async Task<string> Create(TeacherPostDto PostDTO)
        {
            try
            {
                TblTeacher teacher = new TblTeacher()
                {
                    Name = PostDTO.Name,
                    Sex = PostDTO.Sex,
                    
                    Age = PostDTO.Age,
                    Image = PostDTO.Image,

                };
                _context.TblTeachers.Add(teacher);
                _context.SaveChanges();
                return "Sucess";
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the teacher. Please try again.");
            }
        }

        public IEnumerable<TeacherGETDto> Getall()
        {
            var students = (from s in _context.TblTeachers
                            
                            select new TeacherGETDto()
                            {
                                Name = s.Name,
                                Age = s.Age,
                                Sex = s.Sex,
                                
                                Image = s.Image,
                            }
                                              );
            return students;

        }
    }
}
