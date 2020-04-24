using Microsoft.AspNetCore.Mvc;

namespace Classes7.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        public IActionResult GetEnrollments()
        {
            return Ok("Get enrollments");
        }
    }
}