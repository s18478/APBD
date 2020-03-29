using Microsoft.AspNetCore.Mvc;

namespace Classes4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok();
        }
    }
}