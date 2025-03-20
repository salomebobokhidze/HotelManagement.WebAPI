using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelManagement.Core.Entities
{
    public class Guest : IdentityUser
    {
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11)]
        public string PersonalNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
