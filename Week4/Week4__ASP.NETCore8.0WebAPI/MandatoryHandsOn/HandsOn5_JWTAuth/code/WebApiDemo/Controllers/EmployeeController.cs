using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "POC,Admin")]
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
        public IActionResult Put([FromBody] Employee updatedEmp)
        {
            if (updatedEmp.Id <= 0)
                return BadRequest("Invalid employee id");

            var employees = GetStandardEmployeeList();

            var emp = employees.FirstOrDefault(e => e.Id == updatedEmp.Id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;
            emp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(emp);
        }
    }
}
