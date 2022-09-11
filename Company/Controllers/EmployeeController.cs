using Company.Models;
using Company.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ICompanyRepository<Department> departmentRepository;
        private readonly ICompanyRepository<Employee> employeeRepository;

        public EmployeeController(ICompanyRepository<Employee> employeeRepository, ICompanyRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
        }


        [HttpGet("{All}")]

        public IActionResult getAll()
        {
            var employee = employeeRepository.getAll();
            return Ok(employee);

        }


        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var employee = employeeRepository.get(id);
            if (employee == null)
            {
                return BadRequest("Not found");
            }
            return Ok(employee);

        }





        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employeeRepository.Create(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id, Department department)
        {
            employeeRepository.Delete(id);
            return Ok();
        }

    }
}
