using AutoRent.Models;
using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class PaymentResponseDto
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public Booking Booking { get; set; }
    }
}
