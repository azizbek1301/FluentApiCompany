using FluentApiCompany.DataAcsess;
using FluentApiCompany.DTOs;
using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiCompany.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async ValueTask<bool> CreateCompanyAsync(CompanyDto company)
        {
            try
            {
                var comp = new Company()
                {
                    Name = company.Name,
                };
                await _context.Company.AddAsync(comp);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async ValueTask<string> DeleteByIdAsync(int Id)
        {
            try
            {
                var result = await _context.Company.FirstOrDefaultAsync(x => x.Id == Id);
                if (result != null)
                {
                    _context.Company.Remove(result);
                    await _context.SaveChangesAsync();
                    return "Deleted";
                }
                else
                    return "Not found";
            }
            catch (Exception ex)
            {
                return "Xato";
            }
        }

        public async ValueTask<List<Company>> GetAllAsync()
        {
            try
            {
                var result = await _context.Company.AsNoTracking().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Company>();
            }
        }

        public async ValueTask<Company> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.Company.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<bool> UpdateCompanyAsync(int Id, CompanyDto company)
        {
            try
            {
                var com = await _context.Company.FirstOrDefaultAsync(x => x.Id == Id);
                if (com != null)
                {
                    com.Name = company.Name;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
