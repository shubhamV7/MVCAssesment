using System.Data.Entity;

namespace MVCAssesment.MVC.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}