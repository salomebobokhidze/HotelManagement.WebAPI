using System;
using System.Threading.Tasks;
using HotelManagement.Core.DTOs;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Interfaces;
using HotelManagement.Infrastructure.Repositories;

namespace HotelManagement.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public async Task<ReservationDTO> CreateReservationAsync(CreateReservationDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var reservation = new Reservation
            {
                GuestId = dto.GuestId,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate
            };

            await _reservationRepository.AddAsync(reservation);
            return new ReservationDTO(reservation);
        }

        public async Task<bool> UpdateReservationAsync(int id, UpdateReservationDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return false;

            reservation.CheckInDate = dto.CheckInDate;
            reservation.CheckOutDate = dto.CheckOutDate;

            await _reservationRepository.UpdateAsync(reservation);
            return true;
        }

        public async Task<bool> CancelReservationAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid reservation ID", nameof(id));

            return await _reservationRepository.DeleteAsync(id);
        }

        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                throw new KeyNotFoundException("Reservation not found");

            return new ReservationDTO(reservation);
        }
    }
}