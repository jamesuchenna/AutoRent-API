using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class BookingRequestDto
    {
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal PriceTotal { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }
    }
}
