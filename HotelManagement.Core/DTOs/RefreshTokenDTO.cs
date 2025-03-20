using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Core.DTOs
{
    public class RefreshTokenDto
    {
        [Required]
        public string UserId { get; set; }
    }
}
