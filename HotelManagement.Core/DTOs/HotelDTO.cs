using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;

namespace HotelManagement.Core.DTOs
{
    public class HotelDTO
    {
        public HotelDTO(Hotel hotel)
        {
            Hotel = hotel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public Hotel Hotel { get; }
    }
}

