using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Core.DTOs
{
    public class UpdateRoomDTO
    {
        [Required]
        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
