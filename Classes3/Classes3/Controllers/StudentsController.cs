using Microsoft.AspNetCore.Mvc;

namespace Classes3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudents()
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
    }
}