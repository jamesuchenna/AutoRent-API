using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class PaymentRequestDto
    {
        public decimal Amount { get; set; }
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
