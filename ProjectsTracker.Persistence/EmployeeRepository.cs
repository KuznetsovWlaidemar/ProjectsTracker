using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Domain.Models;
using ProjectsTracker.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectsTracker.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Employee employee)
        {

            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task Update(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task Delete(int employeeId)
        {
            _appDbContext.Remove(employeeId);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var result = await _appDbContext.Employees.ToListAsync();
            return result;
        }
        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            var result = await _appDbContext.Employees.FindAsync(employeeId);

            return result;
        }
        public async Task<IEnumerable<Employee>> GetByNameAsync(string employeeName)
        {
            var result = await _appDbContext.Employees.Where(w => w.FirstName == employeeName).ToListAsync();
            return result;
        }
    }
}
