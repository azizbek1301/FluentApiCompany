using FluentApiCompany.DTOs;
using FluentApiCompany.Models;

namespace FluentApiCompany.Services
{
    public interface IPositionService
    {
        public ValueTask<bool> CreatePositionAsync(PositionDto positionDto);
        public ValueTask<List<Position>> GetAllAsync();
        public ValueTask<Position> GetByIdAsync(int id);
        public ValueTask<string> DeleteAsync(int id);
        public ValueTask<string> UpdatePositionAsync(int id, PositionDto positionDto);
    }
}
