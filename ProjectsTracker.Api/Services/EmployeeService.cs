using ProjectsTracker.Domain;

namespace ProjectsTracker.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee>? GetEmployees();
        Employee? GetEmployee(int id);
        Employee? CreateEmployee(Employee project);
        Employee? UpdateEmployee(int id, Employee updatedProject);
        int DeleteEmployee(int id);
    }
    public class EmployeeService
    {

    }
}
