using Microsoft.AspNetCore.Mvc;

namespace Classes6.Controllers
{
    [Route("api/students")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("Hello Students");
        }
    }
}