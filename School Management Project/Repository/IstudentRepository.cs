using School_Management_Project.DTO;

namespace School_Management_Project.Repository
{
    public interface IstudentRepository
    {
        IEnumerable<ClassGroup> Getall(string searchTerm);
      
        IEnumerable<StudentGetDTO> Getall(int Id);
        Task<string> Create(StudentPostDTO PostDTO);
    }
}
