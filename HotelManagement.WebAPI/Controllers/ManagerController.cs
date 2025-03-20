using HotelManagement.Application.Services;
using HotelManagement.Core.DTOs;
using HotelManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.API.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterManager([FromBody] CreateManagerDTO managerDto)
        {
            var result = await _managerService.CreateManagerAsync(managerDto);
            return CreatedAtAction(nameof(GetManagerById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateManager(int id, [FromBody] UpdateManagerDTO managerDto)
        {
            await _managerService.UpdateManagerAsync(id, managerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            await _managerService.DeleteManagerAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerDTO>> GetManagerById(int id)
        {
            var manager = await _managerService.GetManagerByIdAsync(id);
            return Ok(manager);
        }
    }
}
