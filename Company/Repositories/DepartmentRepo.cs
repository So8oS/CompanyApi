using Company.Data;
using Company.Models;

namespace Company.Repositories
{
    public class DepartmentRepo : ICompanyRepository<Department>
    {
        CompanyDbContext db;
        public DepartmentRepo(CompanyDbContext _db)
        {
            db = _db;
        }

        public void Create(Department entity)
        {
            db.Departments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = get(id);
            db.Departments.Remove(department);
            db.SaveChanges();

        }

       
        public Department get(int id)
        {
            return db.Departments.Where(d => d.Id == id).FirstOrDefault();
            
        }

        public IList<Department> getAll()
        {
            return db.Departments.OrderBy(d => d.Id).ToList();
        }

        public void Update(int id, Department newDeprtment)
        {
            db.Update(newDeprtment);
            db.SaveChanges();
        }
    }
}
