using FluentApiCompany.DTOs;
using FluentApiCompany.Models;

namespace FluentApiCompany.Services
{
    public interface IEmployeeService
    {
        public ValueTask<bool> CreateEmployeeAsync(EmployeDto employeDto);
        public ValueTask<List<Employee>> GetAllAsync();
        public ValueTask<Employee> GetByIdAsync(int id);
        public ValueTask<string> DeleteAsync(int id);
        public ValueTask<string> UpdateEmployeeAsync(int id, EmployeDto employeeDto);
    }
}
