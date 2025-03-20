using HotelManagement.Core.DTOs;
using HotelManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.API.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterGuest([FromBody] CreateGuestDTO guestDTO)
        {
            var result = await _guestService.CreateGuestAsync(guestDTO);
            return CreatedAtAction(nameof(GetGuestById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Guest")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] UpdateGuestDTO guestDto)
        {
            await _guestService.UpdateGuestAsync(id, guestDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDTO>> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            return Ok(guest);
        }
    }
}
