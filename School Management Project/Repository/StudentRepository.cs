using School_Management_Project.DTO;
using School_Management_Project.Models;

namespace School_Management_Project.Repository
{
    public class StudentRepository : IstudentRepository
    { private readonly DbschoolContext _context;
        public StudentRepository(DbschoolContext dbschoolContext) {
             _context=dbschoolContext;
        }
        public async Task<string> Create(StudentPostDTO PostDTO)
        {
            try {
                TblStudent student = new TblStudent()
                {
                    Name = PostDTO.Name,
                    Class=PostDTO.Class,
                    Rollnumber=PostDTO.Rollnumber,
                    Age=PostDTO.Age,
                    Image=PostDTO.Image,
                
                };
               _context.TblStudents.Add(student);
                _context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex) {
                throw new Exception("An error occurred while adding the student. Please try again.");
            }
        }

     
        public IEnumerable<ClassGroup> Getall(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var students = (from s in _context.TblStudents
                               
                                select new StudentGetDTO()
                                {
                                    Name = s.Name,
                                    Age = s.Age,
                                    Class = s.Class,
                                    Rollnumber = s.Rollnumber,
                                    Image = s.Image,
                                }
                               );


                return students.GroupBy(s => s.Class)
                               .Select(g => new ClassGroup
                               {
                                   ClassName = g.Key,
                                   Students = g.ToList()
                               })
                               .ToList();
            }
            else
            {
                var students = (from s in _context.TblStudents
                                where s.Name == searchTerm
                                select new StudentGetDTO()
                                {
                                    Name = s.Name,
                                    Age = s.Age,
                                    Class = s.Class,
                                    Rollnumber = s.Rollnumber,
                                    Image = s.Image,
                                }
                                              );


                return students.GroupBy(s => s.Class)
                               .Select(g => new ClassGroup
                               {
                                   ClassName = g.Key,
                                   Students = g.ToList()
                               })
                               .ToList();
            }
        }

        public IEnumerable<StudentGetDTO> Getall(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
