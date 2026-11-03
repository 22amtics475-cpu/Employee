namespace Employee.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee.Model.Employee>> GetAllAsync();
        Task<List<Employee.Model.Employee>> GetJoinedThisMonthAsync();
        Task<Employee.Model.Employee?> GetByIdAsync(int id);
        Task<bool> EmployeeCodeExistsAsync(string code);
        Task<bool> EmployeeTypeExistsAsync(int typeId);
        Task<Employee.Model.Employee> AddAsync(Employee.Model.Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
