using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class DbEmpSet : DbContext
    {
        public DbEmpSet(DbContextOptions<DbEmpSet> options) : base(options)
        {
        }

        public DbSet<Employee.Model.Employee> Employees => Set<Employee.Model.Employee>();
        public DbSet<Employee.Model.EmployeeType> EmployeeTypes => Set<Employee.Model.EmployeeType>();
    }
}
