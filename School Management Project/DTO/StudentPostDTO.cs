namespace School_Management_Project.DTO
{
    public class StudentPostDTO
    {
       
        public string Name { get; set; } 

        public int Age { get; set; }

        public string? Class { get; set; }

        public IFormFile? Images { get; set; }
        public string? Image { get; set; }

        public string Rollnumber { get; set; } 
    }
}
