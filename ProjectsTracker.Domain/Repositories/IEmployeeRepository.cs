using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetByNameAsync(string employeeName);
    }
}
