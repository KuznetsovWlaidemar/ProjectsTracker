using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Api.Contracts.Employee;
using ProjectsTracker.Application.Services;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeService employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            var employee = _employeeService.GetEmployeeAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            await _employeeService.CreateEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeRequest request)
        {
            var existingEmployee = await _employeeService.GetEmployeeAsync(id);
            if (existingEmployee == null)
            {
                return NotFound($"Сотрудник с {id} не найден.");
            }

            _mapper.Map(request, existingEmployee);

            await _employeeService.UpdateEmployee(existingEmployee);

            return Ok(existingEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            // Проверяем, существует ли сотрудник с данным id
            var existingEmployee = await _employeeService.GetEmployeeAsync(id);
            if (existingEmployee == null)
            {
                return NotFound($"Сотрудник с {id} не найден.");
            }

            // Удаляем сотрудника через сервис
            await _employeeService.DeleteEmployee(id);

            return Ok($"Сотрудник с ID {id} был успешно удалён.");
        }
    }
}
