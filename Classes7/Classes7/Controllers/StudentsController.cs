using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Classes7.Models;
using Classes7.Models.DTOs;
using Classes7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Classes7.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IStudentDbService _service;
        private IConfiguration Configuration; 

        public StudentsController(IStudentDbService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("Get Students");
        }

        [HttpPost]
        public IActionResult Login(LoginRequestDto request)
        {

            Student student = _service.GetStudent(request.IndexNumber);

            if (student == null)
            {
                return NotFound("Index number not found !");
            }

            if (!request.Password.Equals(student.Password))
            {
                return Unauthorized("Incorrect password !");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.IndexNumber),
                new Claim(ClaimTypes.Name, student.FirstName),
                new Claim(ClaimTypes.Surname, student.LastName),
                new Claim(ClaimTypes.Role, "employee")    // For testing
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["MySecret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()
            });
        }
    }
}