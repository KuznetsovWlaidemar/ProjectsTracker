using AutoMapper;
using ProjectsTracker.Domain.Models;
using ProjectsTracker.Domain.Repositories;

namespace ProjectsTracker.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task DeleteEmployee(int employee);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns>Сотрудники</returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return employees;
        }

        /// <summary>
        /// Получить сотрудника по Id
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Сотрудник</returns>
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            return employee;
        }

        /// <summary>
        /// Создать нового сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Сотрудник</returns>
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _employeeRepository.Add(employee);
            return employee;

        }

        /// <summary>
        /// Изменить сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="updatedEmployee">Сотрудник</param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            await _employeeRepository.Update(updatedEmployee);
            return updatedEmployee;
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public async Task DeleteEmployee(int employeeId)
        {
            await _employeeRepository.Delete(employeeId);
        }
    }
}
