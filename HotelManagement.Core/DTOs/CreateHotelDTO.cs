using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

    namespace HotelManagement.Core.DTOs
    {
        public class CreateHotelDTO
        {
            [Required]
            public required string Name { get; set; }

            [Range(1, 5)]
            public int Rating { get; set; }

            [Required]
            public required string Country { get; set; }

            [Required]
            public required string City { get; set; }

            [Required]
            public required string Address { get; set; }

            [Required]
            public int ManagerId { get; set; }
        }
    }
