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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        
        public async Task<HotelDTO> CreateHotelAsync(CreateHotelDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var hotel = new Hotel
            {
                Name = dto.Name,
                Rating = dto.Rating,
                Country = dto.Country,
                City = dto.City,
                Address = dto.Address
            };

            await _hotelRepository.AddAsync(hotel);
            return new HotelDTO(hotel);
        }

      
        public async Task<HotelDTO> GetHotelByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid hotel ID", nameof(id));

            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return null;

            return new HotelDTO(hotel);
        }

        
        public async Task<IEnumerable<HotelDTO>> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            return hotels.Select(h => new HotelDTO(h));
        }

        
        public async Task<IEnumerable<HotelDTO>> GetAllHotelsAsync(int page, int pageSize, string filter)
        {
            if (page <= 0)
                throw new ArgumentException("Page number must be greater than 0", nameof(page));
            if (pageSize <= 0)
                throw new ArgumentException("Page size must be greater than 0", nameof(pageSize));

            IEnumerable<Hotel> hotels;

            if (!string.IsNullOrEmpty(filter))
            {
                hotels = await _hotelRepository.GetFilteredHotelsAsync(filter);
            }
            else
            {
                hotels = await _hotelRepository.GetAllAsync();
            }

            
            var paginatedHotels = hotels
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return paginatedHotels.Select(h => new HotelDTO(h));
        }

        
        public async Task<bool> UpdateHotelAsync(int id, UpdateHotelDTO dto)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid hotel ID", nameof(id));
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return false;

            hotel.Name = dto.Name;
            hotel.Rating = dto.Rating;
            hotel.Country = dto.Country;
            hotel.City = dto.City;
            hotel.Address = dto.Address;

            await _hotelRepository.UpdateAsync(hotel);
            return true;
        }

        
        public async Task<bool> DeleteHotelAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid hotel ID", nameof(id));

            return await _hotelRepository.DeleteAsync(id);
        }
    }
}