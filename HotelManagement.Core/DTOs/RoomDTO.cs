using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;

namespace HotelManagement.Core.DTOs
{
    public class RoomDTO
    {
        public RoomDTO(Room room)
        {
            Room = room;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public int HotelId { get; set; }
        public Room Room { get; }
    }
}
