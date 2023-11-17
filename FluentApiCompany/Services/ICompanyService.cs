using FluentApiCompany.DTOs;
using FluentApiCompany.Models;

namespace FluentApiCompany.Services
{
    public interface ICompanyService
    {
        public ValueTask<bool> CreateCompanyAsync(CompanyDto company);
        public ValueTask<List<Company>> GetAllAsync();
        public ValueTask<Company> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int Id);
        public ValueTask<bool> UpdateCompanyAsync(int Id, CompanyDto company);
    }
}
