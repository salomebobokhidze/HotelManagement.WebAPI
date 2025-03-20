using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.DTOs;

namespace HotelManagement.Core.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDTO> CreateRoomAsync(CreateRoomDTO dto);
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync();
        Task<bool> UpdateRoomAsync(int id, UpdateRoomDTO dto);
        Task<bool> DeleteRoomAsync(int id);
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync(int? hotelId, bool? isAvailable, decimal? minPrice, decimal? maxPrice);
        Task<RoomDTO> GetRoomByIdAsync(int id);
        }
    }
