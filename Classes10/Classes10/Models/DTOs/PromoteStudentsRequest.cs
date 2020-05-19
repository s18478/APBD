using System.ComponentModel.DataAnnotations;

namespace Classes10.Models.DTOs
{
    public class PromoteStudentsRequest
    {
        [Required]
        public string Studies { get; set; }
        
        [Required]
        public int Semester { get; set; }
    }
}