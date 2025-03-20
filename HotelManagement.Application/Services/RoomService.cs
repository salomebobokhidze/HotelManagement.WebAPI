using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Core.DTOs;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Interfaces;
using HotelManagement.Infrastructure.Repositories;

namespace HotelManagement.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public async Task<RoomDTO> CreateRoomAsync(CreateRoomDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var room = new Room
            {
                Name = dto.Name,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price,
                HotelId = dto.HotelId
            };

            await _roomRepository.AddAsync(room);
            return new RoomDTO(room);
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Select(r => new RoomDTO(r));
        }

        public async Task<bool> UpdateRoomAsync(int id, UpdateRoomDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
                return false;

            room.Name = dto.Name;
            room.IsAvailable = dto.IsAvailable;
            room.Price = dto.Price;

            await _roomRepository.UpdateAsync(room);
            return true;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid room ID", nameof(id));

            return await _roomRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<RoomDTO>> GetAllRoomsAsync(int? hotelId, bool? isAvailable, decimal? minPrice, decimal? maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<RoomDTO> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}