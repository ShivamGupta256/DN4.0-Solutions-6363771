using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("Emp")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<string> employees = new List<string>
        {
            "Alice", "Bob", "Charlie"
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }
    }
}
