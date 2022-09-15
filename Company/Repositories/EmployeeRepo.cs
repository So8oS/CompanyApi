using Company.Data;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories
{
    public class EmployeeRepo : ICompanyRepository<Employee>
    {

        CompanyDbContext db;
        public EmployeeRepo(CompanyDbContext _db)
        {
            db = _db;
        }

        public void Create(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = get(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public Employee get(int id)
        {
            return db.Employees.Where(d => d.Id == id).Include(x => x.Department).FirstOrDefault();
        }

        public IList<Employee> getAll()
        {
            return db.Employees.OrderBy(d => d.Id)
                .Include(x => x.Department)
                .ToList();
        }

        public void Update(int id, Employee newEmployee)
        {
            db.Update(newEmployee);
            db.SaveChanges();
        }
    }
}
