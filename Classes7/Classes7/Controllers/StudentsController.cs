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

            string accessToken = GenerateAccessToken(student);
            string refreshToken = GenerateAndSaveRefreshToken(student.IndexNumber);
            
            return Ok(new
            {
                accessToken,    
                refreshToken
            });
        }

        [HttpGet("refresh-token/{refreshToken}")]
        public IActionResult RefreshToken(string refreshToken)
        {
            Student student = _service.GetStudentByRefreshToken(refreshToken);

            if (student == null)
            {
                return NotFound("Refresh token not found !");
            }
            
            string accessToken = GenerateAccessToken(student);
            string newRefreshToken = GenerateAndSaveRefreshToken(student.IndexNumber);
            
            return Ok(new
            {
                accessToken,    
                newRefreshToken
            });
        }

        public string GenerateAccessToken(Student student)
        {
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
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateAndSaveRefreshToken(string indexNumber)
        {
            var refreshToken = Guid.NewGuid().ToString();
            
            _service.SaveRefreshToken(indexNumber, refreshToken);

            return refreshToken;
        }
    }
}