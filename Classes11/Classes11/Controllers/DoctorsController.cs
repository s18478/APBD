using Microsoft.AspNetCore.Mvc;

namespace Classes11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok();
        }
    }
}