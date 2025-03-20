using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.DTOs;

namespace HotelManagement.Core.Interfaces
{
    public interface IGuestService
    {
        Task<GuestDTO> CreateGuestAsync(CreateGuestDTO dto);
        Task<bool> UpdateGuestAsync(int id, UpdateGuestDTO dto);
        Task<bool> DeleteGuestAsync(int id);
        Task<GuestDTO> GetGuestByIdAsync(int id);
    }
}
