namespace School_Management_Project.DTO
{
    public class SubjectWithTeachersDTO
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<TeacherGETDto> Teachers { get; set; }

    }
}
