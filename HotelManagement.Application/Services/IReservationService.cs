using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.DTOs;

namespace HotelManagement.Core.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDTO> CreateReservationAsync(CreateReservationDTO dto);
        Task<bool> UpdateReservationAsync(int id, UpdateReservationDTO dto);
        Task<bool> CancelReservationAsync(int id);
        Task<ReservationDTO> GetReservationByIdAsync(int id);
    }
}
