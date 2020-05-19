using System;
using System.ComponentModel.DataAnnotations;

namespace Classes10.Models.DTOs
{
    public class EnrollStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Studies { get; set; }
    }
}