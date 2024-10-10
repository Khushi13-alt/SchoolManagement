namespace School_Management_Project.DTO
{
    public class TeacherPostDto
    {
        public string Name { get; set; }
        public IFormFile? Images { get; set; }
        public string? Image { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; } 
    }
}
