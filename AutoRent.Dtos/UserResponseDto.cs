using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CompletedRegistration { get; set; }
        public bool Verified { get; set; }

        public List<BookingResponseDto> Bookings { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<PaymentResponseDto> Payments { get; set; }
    }
}
