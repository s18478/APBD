using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Classes10.Models;
using Classes10.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Classes10.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var db = new MyDbContext();
            
            var studies = db.Studies
                .FirstOrDefault(st => st.Name == request.Studies);

            if (studies == null)
            {
                return NotFound("Studies not found.");
            }

            var enrollment = db.Enrollment.FirstOrDefault(enr => enr.IdStudy == studies.IdStudy && enr.Semester == 1);

            if (enrollment == null)
            {
                var maxIndex = db.Enrollment.Max(enr => enr.IdEnrollment);
                
                enrollment = new Enrollment
                {
                    IdEnrollment = maxIndex + 1,
                    Semester = 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now.Date
                };

                db.Enrollment.Add(enrollment);
                db.SaveChanges();
            }

            if (db.Student.Any(st => st.IndexNumber == request.IndexNumber))
            {
                return BadRequest("Index exists!");
            }

            Student student = new Student
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,    
                BirthDate = request.BirthDate,
                IdEnrollment = enrollment.IdEnrollment
            };

            db.Student.Add(student);
            db.SaveChanges();
            
            return Ok(student);
        }

        [HttpPost("promotions")]
        public IActionResult PromoteStudents(PromoteStudentsRequest request)
        {
            var db = new MyDbContext();

            var studies = db.Studies.FirstOrDefault(study => study.Name == request.Studies);

            if (studies == null)
            {
                return NotFound("Studies not found!");
            }

            var enrollment = db.Enrollment.FirstOrDefault(enroll =>
                enroll.Semester == request.Semester && enroll.IdStudy == studies.IdStudy);
            
            if (enrollment == null)
            {
                return NotFound("Enrollment not found!");
            }

            var previousIdEnrollment = enrollment.IdEnrollment;
            
            enrollment = db.Enrollment.FirstOrDefault(enroll =>
                enroll.Semester == request.Semester + 1 && enroll.IdStudy == studies.IdStudy);

            if (enrollment == null)
            {
                var maxIndex = db.Enrollment.Max(enroll => enroll.IdEnrollment);
                enrollment = new Enrollment
                {
                    IdEnrollment = maxIndex + 1,
                    Semester = request.Semester + 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now.Date
                };

                db.Add(enrollment);
                db.SaveChanges();
            }

            var students = db.Student.Where(st => st.IdEnrollment == previousIdEnrollment);
            
            foreach (Student student in students)
            {
                student.IdEnrollment = enrollment.IdEnrollment;
            }
    
            db.SaveChanges();

            return Ok("Promotion successful :)");
        }
    }
}