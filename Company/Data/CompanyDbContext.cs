using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class CompanyDbContext : DbContext 
    {

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }  

    }
}
