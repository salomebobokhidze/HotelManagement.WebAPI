using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Core.DTOs
{
    public class RevokeTokenDto
    {
        [Required]
        public string UserId { get; set; }
    }
}

