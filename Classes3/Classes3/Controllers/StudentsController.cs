using System;
using Classes3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classes3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /*
        [HttpGet]
        public string GetStudents()
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
        */

        // QueryString
        [HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski, order by = {orderBy}";
        }
        
        // URL segment

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Student was not found");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            // Add student with random index to database
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";

            return Ok(student);
        }
    }
}