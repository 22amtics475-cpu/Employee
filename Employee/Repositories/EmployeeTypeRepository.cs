using Employee.Data;
using Employee.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly DbEmpSet _context;

        public EmployeeTypeRepository(DbEmpSet context)
        {
            _context = context;
        }

        public async Task<bool> TypeNameExistsAsync(string typeName)
        {
            return await _context.EmployeeTypes
                .AnyAsync(t => t.TypeName.ToLower() == typeName.ToLower());
        }

        public async Task<EmployeeType> AddAsync(EmployeeType employeeType)
        {
            _context.EmployeeTypes.Add(employeeType);
            await _context.SaveChangesAsync();
            return employeeType;
        }

        public async Task<List<EmployeeType>> GetAllAsync()
        {
            return await _context.EmployeeTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EmployeeType?> GetByIdAsync(int id)
        {
            return await _context.EmployeeTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.EmmployeeTypeId == id);
        }
    }
}