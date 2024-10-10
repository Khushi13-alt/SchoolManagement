using School_Management_Project.DTO;
using School_Management_Project.Models;

namespace School_Management_Project.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DbschoolContext _context;
        public SubjectRepository(DbschoolContext dbschoolContext)
        {
            _context = dbschoolContext;
        }
        public async Task<string> Create(SubjectPostDTO PostDTO)
        {
            TblSubject subject = new TblSubject()
            {
                Class = PostDTO.Class,
                Name = PostDTO.Name,

            };
            _context.TblSubjects.Add(subject);
            _context.SaveChanges();
            if (PostDTO.LanguageIds != null && PostDTO.LanguageIds.Count > 0)
            {
                foreach (var languageId in PostDTO.LanguageIds)
                {
                    TblSubjectLanguage language = new TblSubjectLanguage()
                    {
                        SubjectId=subject.Id,
                        LanguageId=languageId
                    };
                    _context.TblSubjectLanguages.Add(language);
                    _context.SaveChanges() ;
                }
            }
            return "Subject";
        }

        public IEnumerable<TeacherGETDto> Getall()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectWithTeachersDTO> GetAllSubjectsWithTeachers()
        {
            var subjectsWithTeachers = from subject in _context.TblSubjects
                                       select new SubjectWithTeachersDTO
                                       {
                                           SubjectId = subject.Id,
                                           SubjectName = subject.Name,
                                           Teachers = (from st in _context.TeacherSubjects
                                                       where st.SubjectId == subject.Id
                                                       select new TeacherGETDto
                                                       {
                                                            Id= st.Teacher.Id,
                                                           Name = st.Teacher.Name
                                                       }).ToList()
                                       };

            return subjectsWithTeachers.ToList();
        }

        public IEnumerable<LanguageGetDto> GetLanguage()
        {
            var language = (from l in _context.TblLanguages
                            select new LanguageGetDto()
                            {
                                Id = l.Id,
                                Name = l.Name,
                            });
            return language;
        }
    }
}
