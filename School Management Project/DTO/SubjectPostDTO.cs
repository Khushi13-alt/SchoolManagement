using Microsoft.AspNetCore.Mvc.Rendering;

namespace School_Management_Project.DTO
{
    public class SubjectPostDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string Class { get; set; } 

        public int? TeacherId { get; set; }
        public int? LanguageId { get; set; }
        public List<int> LanguageIds { get; set; }

        
    }
}
