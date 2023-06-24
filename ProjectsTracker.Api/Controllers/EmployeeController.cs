using AutoMapper;
using EmployeesTracker.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Api.Dto.Employees;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public EmployeeController(IEmployeeService employeeService,
                                 IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
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
                var employeesDto = _mapper.Map<EmployeeDto>(employees);
                return Ok(employeesDto);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при получении списка сотрудников.");
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

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeDto);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при получении сотрудника.");
            }
        }

        // POST: api/employees
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                employeeDto = _mapper.Map<EmployeeDto>(_employeeService.CreateEmployee(employee));
                return Ok(employeeDto);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при создании сотрудника.");
            }
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDto updatedEmployeeDto)
        {
            try
            {
                var updatedEmployee = _mapper.Map<Employee>(updatedEmployeeDto);
                var employee = _mapper.Map<EmployeeDto>(_employeeService.UpdateEmployee(id, updatedEmployee));
                return Ok(employee);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при изменении сотрудника.");
            }
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _employeeService.DeleteEmployee(employee);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при удалении сотрудника.");
            }
        }
        #endregion
    }
}
