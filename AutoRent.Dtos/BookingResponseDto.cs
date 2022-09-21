using AutoRent.Models;
using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class BookingResponseDto
    {
        public string Id { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal PriceTotal { get; set; }
        public CarResponseDto Car { get; set; }
        public UserResponseDto User { get; set; }
        public PaymentResponseDto PaymentResponseDto { get; set; }
        public BookingStatus Status { get; set; }
        public Rating Rating { get; set; }
    }
}
