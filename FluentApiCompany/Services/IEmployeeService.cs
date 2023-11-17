using FluentApiCompany.DTOs;
using FluentApiCompany.Models;

namespace FluentApiCompany.Services
{
    public interface IEmployeeService
    {
        public ValueTask<bool> CreateEmployeeAsync(EmployeDto employeDto);
        public ValueTask<List<Employee>> GetAllAsync();
        public ValueTask<Employee> GetByIdAsync(int id);
        public ValueTask<bool> DeleteAsync(int id);
        public ValueTask<bool> UpdateEmployeeAsync(int id, EmployeDto employeeDto);
    }
}
