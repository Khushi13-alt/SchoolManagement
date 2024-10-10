namespace School_Management_Project.DTO
{
    public class ClassGroup
    {
        public string ClassName { get; set; }
        public List<StudentGetDTO> Students { get; set; }
    }
    public class StudentGetDTO
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Class { get; set; }

        public string? Image { get; set; }

        public string? Rollnumber { get; set; }
    }
}
