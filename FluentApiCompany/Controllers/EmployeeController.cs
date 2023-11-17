using FluentApiCompany.DataAcsess;
using FluentApiCompany.DTOs;
using FluentApiCompany.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentApiCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService, AppDbContext appDbContext)
        {
            _employeeService = employeeService;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateEmployeeAsync(EmployeDto employeeDto)
        {
            var res = _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(res);
        }

        [HttpGet("GetAll")]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _employeeService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("ById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _employeeService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpDelete("ById")]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _employeeService.DeleteAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateEmployeeById(int id, EmployeDto employeeDto)
        {
            var res = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
            return Ok(res);
        }
    }
}
