using FluentApiCompany.DataAcsess;
using FluentApiCompany.DTOs;
using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiCompany.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext appDbContext)
        {
            _context = appDbContext;
            
        }
        public async ValueTask<bool> CreateEmployeeAsync(EmployeDto employeDto)
        {
            try
            {
                var res = new Employee()
                {
                    Name = employeDto.Name,
                    Surname = employeDto.Surname,
                    PositionId = employeDto.PositionId,
                };
                await _context.Employees.AddAsync(res);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async ValueTask<string> DeleteAsync(int id)
        {
            try
            {
                var res = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(res !=null)
                {
                    _context.Employees.Remove(res);
                    await _context.SaveChangesAsync();
                    return "Deleted";
                }
                else
                {
                    return "Not Found";
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async ValueTask<List<Employee>> GetAllAsync()
        {
            try
            {
                var res = await _context.Employees.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Employee> GetByIdAsync(int id)
        {
            try
            {
                var res = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateEmployeeAsync(int id, EmployeDto employeeDto)
        {
            try
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (emp != null)
                {
                    emp.PositionId = employeeDto.PositionId;
                    emp.Name = employeeDto.Name;
                    emp.Surname = employeeDto.Surname;
                    await _context.SaveChangesAsync();
                    return "Employee Updated";
                }
                else
                {
                    return "Employee not found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
