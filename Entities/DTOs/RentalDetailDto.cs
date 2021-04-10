using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
