using Company.Data;
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




        
        [HttpPost("createdee")]
        public ActionResult Create(Department department)
        {
            departmentRepository.Create(department);
            return Ok(department);
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            

            departmentRepository.Delete(id);
            return Ok("Department Deleted");
        }


        /*



        [HttpPut]
        public async Task<ActionResult<List<Department>>> UpdateDepartment(Department request)
        {
            var department = await _db.Departments.FindAsync(request.Id);
            if (department == null)
            {
                return BadRequest("Not found");
            }
            await _db.SaveChangesAsync();
            return Ok(await _db.Departments.ToListAsync());
         }



        [HttpDelete("{id}")]
            
        public async Task<ActionResult<List<Department>>> DeleteDepartment( int id)
        {
            var department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return BadRequest("Not found");
            }
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();

            return Ok(await _db.Departments.ToListAsync());
        }*/
    }
}
