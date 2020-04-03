using Microsoft.AspNetCore.Mvc;

namespace Classes5.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}