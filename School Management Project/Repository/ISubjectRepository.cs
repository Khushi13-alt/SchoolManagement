using School_Management_Project.DTO;

namespace School_Management_Project.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<LanguageGetDto> GetLanguage();
        IEnumerable<TeacherGETDto> Getall();
        IEnumerable<SubjectWithTeachersDTO> GetAllSubjectsWithTeachers();


        Task<string> Create(SubjectPostDTO PostDTO);
    }
}
