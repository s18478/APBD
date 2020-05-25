using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Classes11.Models.DTOs
{
    public class CreateDoctorRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}