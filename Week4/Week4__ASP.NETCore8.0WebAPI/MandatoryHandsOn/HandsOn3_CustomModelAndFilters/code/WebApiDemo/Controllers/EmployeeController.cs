using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET" }
                    }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            //throw new Exception("Demo error"); // Uncomment to test exception
            return Ok(_employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            return Ok($"Received: {employee.Name}");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            return Ok($"Updated: {employee.Name}");
        }
    }
}
