using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Classes10.Models;
using Classes10.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classes10.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var db = new MyDbContext();

            return Ok(db.Student.ToList());
        }

        [HttpPut("{index}")]
        public IActionResult UpdateStudent(string index, UpdateStudentRequest request)
        {
            if (request.FirstName == null || request.LastName == null)
            {
                return BadRequest("First name or last name is empty!");
            }
         
            var db = new MyDbContext();
            
            Student student = new Student
            {
                IndexNumber = index,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            
            db.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("Update successful!");
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteStudent(string index)
        {
            var db = new MyDbContext();
            
            var student = db.Student.Find(index);
            
            if (student == null)
            {
                return BadRequest("Student not found.");
            }
            
            db.Remove(student);
            db.SaveChanges();

            return Ok("Student deleted.");
        }
    }
}