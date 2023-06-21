using AutoMapper;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int id);
        EmployeeDto CreateEmployee(EmployeeDto employee);
        EmployeeDto UpdateEmployee(int id, EmployeeDto updatedProject);
        int DeleteEmployee(int id);
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
        /// Извлекает всех сотрудников
        /// </summary>
        /// <returns>Все проекты</returns>
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            try
            {
                var employees = _dbContext.Employees.ToList();
                var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return employeeDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении сотрудников: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Извлекает сотрудника по Id
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Найденный сотрудник</returns>
        public EmployeeDto GetEmployee(int id)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(p => p.Id == id);
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении сотрудника: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Создаёт нового сотрудника
        /// </summary>
        /// <param name="employee">Создаваемый сотрудник</param>
        /// <returns>Созданный сотрудник</returns>
        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);

                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employeeDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при создании сотрудника: " + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Изменяет сотрудника 
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="updatedProject">Данные для обновления</param>
        /// <returns>Изменённый сотрудник</returns>
        public EmployeeDto UpdateEmployee(int id, EmployeeDto updatedEmployeeDto)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(p => p.Id == id);

                employee = _mapper.Map<Employee>(updatedEmployeeDto);

                _dbContext.SaveChanges();
                return updatedEmployeeDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при изменении сотрудника: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Удаляет сотрудника по Id
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Статус код</returns>
        public int DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null)
                return 1;

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return 0;
        }
        #endregion
    }
}
