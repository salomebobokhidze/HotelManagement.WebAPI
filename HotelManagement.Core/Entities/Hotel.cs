using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
