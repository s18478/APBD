using Microsoft.AspNetCore.Mvc;

namespace Classes7.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        public IActionResult GetStudents()
        {
            return Ok("Get Students");
        }
    }
}