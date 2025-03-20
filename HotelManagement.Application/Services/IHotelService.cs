using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.DTOs;

namespace HotelManagement.Core.Interfaces
{
    public interface IHotelService
    {
        Task<HotelDTO> CreateHotelAsync(CreateHotelDTO dto);
        Task<HotelDTO> GetHotelByIdAsync(int id);
        Task<IEnumerable<HotelDTO>> GetAllHotelsAsync();
        Task<bool> UpdateHotelAsync(int id, UpdateHotelDTO dto);
        Task<bool> DeleteHotelAsync(int id);
        Task<IEnumerable<HotelDTO>> GetAllHotelsAsync(int page, int pageSize, string filter);
    }
}
