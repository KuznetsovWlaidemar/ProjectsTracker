using AutoMapper;
using ProjectsTracker;
using ProjectsTracker.Domain.Employees;

namespace EmployeesTracker.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(int id, Employee updatedEmployee);
        void DeleteEmployee(Employee employee);
    }
    public class EmployeeService : IEmployeeService
    {
        #region Fields
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public EmployeeService(DbContext dbContext,
                              IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns>Сотрудники</returns>
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _dbContext.Employees.ToList();
            return employees;
        }

        /// <summary>
        /// Получить сотрудника по Id
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Сотрудник</returns>
        public Employee GetEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
            {
                throw new Exception("Сотрудник не найден");
            }
            return employee;
        }

        /// <summary>
        /// Создать нового сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Сотрудник</returns>
        public Employee CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        /// <summary>
        /// Изменить сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="updatedEmployee">Сотрудник</param>
        /// <returns></returns>
        public Employee UpdateEmployee(int id, Employee updatedEmployee)
        {
            try
            {
                var existingEmployee = GetEmployee(id);

                _mapper.Map(updatedEmployee, existingEmployee);
                _dbContext.SaveChanges();
                return existingEmployee;
            }
            catch
            {
                throw new Exception("Произошла ошибка при изменении сотрудника.");
            }
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public void DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
