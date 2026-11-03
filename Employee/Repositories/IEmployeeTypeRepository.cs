using Employee.Model;

namespace Employee.Repositories
{
    public interface IEmployeeTypeRepository
    {
        Task<List<EmployeeType>> GetAllAsync();
        Task<EmployeeType?> GetByIdAsync(int id);
        Task<bool> TypeNameExistsAsync(string typeName);
        Task<EmployeeType> AddAsync(EmployeeType employeeType);
    }
}
