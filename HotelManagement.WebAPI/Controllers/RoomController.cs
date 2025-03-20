using HotelManagement.Core.DTOs;
using HotelManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.API.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddRoom([FromBody] CreateRoomDTO roomDto)
        {
            var result = await _roomService.CreateRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoomById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomDTO roomDto)
        {
            await _roomService.UpdateRoomAsync(id, roomDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAllRooms([FromQuery] int? hotelId, [FromQuery] bool? isAvailable, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var rooms = await _roomService.GetAllRoomsAsync(hotelId, isAvailable, minPrice, maxPrice);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            return Ok(room);
        }
    }
}
