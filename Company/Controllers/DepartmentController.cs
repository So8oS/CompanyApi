using Company.Data;
using Company.Dtos;
using Company.Models;
using Company.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ICompanyRepository<Department> departmentRepository;

        public DepartmentController(ICompanyRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }


        [HttpGet]

        public IActionResult getAll()
        {
            var departments = departmentRepository.getAll();
            return Ok(departments);

        }


        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var department = departmentRepository.get(id);
            if (department == null)
            {
                return BadRequest("Not found");
            }
            return Ok(department);

        }




        
        [HttpPost]
        public ActionResult Create(DepartmentDto departmentDto)
        {
            Department department = new Department
            {
                Name = departmentDto.Name,

            };
            departmentRepository.Create(department);
            return Ok(department);
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            departmentRepository.Delete(id);
            return Ok();
        }






        [HttpPut]
        public ActionResult UpdateDepartment(int id, DepartmentDto request)
        {
            

            var department = new Department
            {
                Id = id,
                Name = request.Name,
            };

            departmentRepository.Update(id, department);
            return Ok(department);
        }




    }
}
