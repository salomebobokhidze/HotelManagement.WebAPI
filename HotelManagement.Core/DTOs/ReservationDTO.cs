using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;

namespace HotelManagement.Core.DTOs
{
    public class ReservationDTO
    {
        public ReservationDTO(Reservation reservation)
        {
            Reservation = reservation;
        }

        public int Id { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public int HotelId { get; set; }
        public Reservation Reservation { get; }
    }
}
