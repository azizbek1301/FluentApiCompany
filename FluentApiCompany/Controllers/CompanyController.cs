using FluentApiCompany.DTOs;
using FluentApiCompany.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentApiCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCompanyAsync(CompanyDto companyDto)
        {
            var res = _companyService.CreateCompanyAsync(companyDto);
            return Ok(res);
        }

        [HttpGet("GetAll")]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _companyService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("ById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _companyService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpDelete("ById")]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _companyService.DeleteByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCompanyById(int id, CompanyDto companyDto)
        {
            var res = await _companyService.UpdateCompanyAsync(id, companyDto);
            return Ok(res);
        }
    }
}
