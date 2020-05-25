using Classes11.Models.DTOs;
using Classes11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Classes11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorDbService _service;

        public DoctorsController(IDoctorDbService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [HttpPost("create")]
        public IActionResult CreateDoctor(CreateDoctorRequest request)
        {
            return Ok(_service.CreateDoctor(request));
        }
    }
}