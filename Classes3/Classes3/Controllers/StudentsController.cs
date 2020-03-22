using System;
using System.Linq;
using Classes3.DAL;
using Classes3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classes3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        // Using artificial database
        [HttpGet]
        public IActionResult GetStudents([FromQuery] string orderBy)
        {
            if (orderBy == "lastName")
            {
                return Ok(_dbService.GetStudents().OrderBy(s => s.LastName));
            }
            
            return Ok(_dbService.GetStudents());
        }
        
        /*
        [HttpGet]
        public string GetStudents()
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
        */

        /* QueryString
        [HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski, order by = {orderBy}";
        }
        */
        
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

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            if (id > 0 && id < 20000)
                return Ok("Update successful");
            
            return NotFound("Student was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok($"Student {id} deleted");
        }
    }
}