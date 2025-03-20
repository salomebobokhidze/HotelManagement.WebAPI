using HotelManagement.Core.Entities;

namespace HotelManagement.Core.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }


        public GuestDTO(Guest guest)
        {
            
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            PhoneNumber = guest.PhoneNumber;
            PersonalNumber = guest.PersonalNumber;
        }
    }
}
