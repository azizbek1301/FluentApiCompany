using FluentApiCompany.DataAcsess;
using FluentApiCompany.DTOs;
using FluentApiCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiCompany.Services
{
    public class PositionService : IPositionService
    {
        private readonly AppDbContext _context;
        public PositionService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async ValueTask<bool> CreatePositionAsync(PositionDto positionDto)
        {
            try
            {
                var position = new Position()
                {
                    Name = positionDto.Name,
                    CompanyId = positionDto.CompanyId,
                };
                await _context.Positions.AddAsync(position);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<string> DeleteAsync(int id)
        {
            try
            {
                var res = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _context.Positions.Remove(res);
                    await _context.SaveChangesAsync();
                    return "Position Deleted";
                }
                else { return "Position not Found!"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Position>> GetAllAsync()
        {
            try
            {
                var res = await _context.Positions.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Position> GetByIdAsync(int id)
        {
            try
            {
                var res = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdatePositionAsync(int id, PositionDto positionDto)
        {
            try
            {
                var stf = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
                if (stf != null)
                {
                    stf.Name = positionDto.Name;
                    stf.CompanyId = positionDto.CompanyId;
                    await _context.SaveChangesAsync();
                    return "Position Updated";
                }
                else
                {
                    return "Position not found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
