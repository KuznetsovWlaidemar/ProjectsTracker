using ProjectsTracker.Domain.Employees;

namespace ProjectsTracker.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int id);
        EmployeeDto CreateEmployee(EmployeeDto project);
        EmployeeDto UpdateEmployee(int id, EmployeeDto updatedProject);
        int DeleteEmployee(int id);
    }
    public class EmployeeService
    {

    }
}
