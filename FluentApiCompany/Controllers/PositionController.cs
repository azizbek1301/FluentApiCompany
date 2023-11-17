using FluentApiCompany.DataAcsess;
using FluentApiCompany.DTOs;
using FluentApiCompany.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentApiCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPositionService _positionServices;
        public PositionController(IPositionService positionService, AppDbContext appDbContext)
        {
            _positionServices = positionService;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePostionAsync(PositionDto staffDto)
        {
            var res = _positionServices.CreatePositionAsync(staffDto);
            return Ok(res);
        }

        [HttpGet("GetAll")]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _positionServices.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("ById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _positionServices.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpDelete("ById")]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _positionServices.DeleteAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdatePositonById(int id, PositionDto positionDto)
        {
            var res = await _positionServices.UpdatePositionAsync(id, positionDto);
            return Ok(res);
        }

        [HttpGet("Ex")]
        public async ValueTask<IActionResult> GetExPosition(int id)
        {
            try
            {
                var res = await _appDbContext.Positions.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
