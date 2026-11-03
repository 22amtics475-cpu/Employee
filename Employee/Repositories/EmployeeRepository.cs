using Employee.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbEmpSet _context;

        public EmployeeRepository(DbEmpSet context)
        {
            _context = context;
        }

        public async Task<List<Employee.Model.Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.EmployeeType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Employee.Model.Employee>> GetJoinedThisMonthAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var firstDay = new DateOnly(today.Year, today.Month, 1);
            var firstDayNextMonth = firstDay.AddMonths(1);

            return await _context.Employees
                .Include(e => e.EmployeeType)
                .AsNoTracking()
                .Where(e => e.JoiningDate >= firstDay &&
                            e.JoiningDate < firstDayNextMonth)
                .ToListAsync();
        }

        public async Task<Employee.Model.Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.EmployeeType)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> EmployeeCodeExistsAsync(string code)
        {
            return await _context.Employees
                .AnyAsync(e => e.EmployeeCode == code);
        }

        public async Task<bool> EmployeeTypeExistsAsync(int typeId)
        {
            return await _context.EmployeeTypes
                .AnyAsync(t => t.EmmployeeTypeId == typeId);
        }

        public async Task<Employee.Model.Employee> AddAsync(
            Employee.Model.Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees
                .FindAsync(id);

            if (employee is null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
