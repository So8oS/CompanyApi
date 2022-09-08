using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
      
        private readonly CompanyDbContext _db;

        public DepartmentController(CompanyDbContext db )
        {
            _db = db;
        }



        [HttpGet]

        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _db.Departments.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            var department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return BadRequest("Not found");
            }
            return Ok(department);

        }



        

        [HttpPost]
        public async Task<ActionResult <List<Department>>> addDepartment(Department department)
        {
            _db.Departments.Add(department);
            await _db.SaveChangesAsync();
            return Ok(await _db.Departments.ToListAsync());
        }



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
        }
    }
}
