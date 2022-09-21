using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoRent.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public PaymentStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Booking")]
        public string BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
