using School_Management_Project.DTO;

namespace School_Management_Project.Repository
{
    public interface ITeacherRepository
    {
        IEnumerable<TeacherGETDto> Getall();


        Task<string> Create(TeacherPostDto PostDTO);
    }
}
