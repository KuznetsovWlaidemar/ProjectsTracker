using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Projects;
using ProjectsTracker.Services;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructors
        public EmployeeController(IEmployeeService employeeService,
                                 IMapper mapper)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Methods
        // GET: api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при получении списка сотрудников." + ex.Message);
            }
        }
        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployee(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при получении сотрудника." + ex.Message);
            }
        }
        // POST: api/employees
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employee)
        {
            try
            {
                _employeeService.CreateEmployee(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при создании сотрудника." + ex.Message);
            }
        }
        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDto updatedEmployee)
        {
            try
            {
                var employee = _employeeService.UpdateEmployee(id, updatedEmployee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при обновлении сотрудника." + ex.Message);
            }
        }
        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при удалении сотрудника." + ex.Message);
            }
        }
        #endregion
    }
}
