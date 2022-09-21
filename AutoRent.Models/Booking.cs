using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoRent.Models
{
    public class Booking
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public decimal PriceTotal { get; set; }
        [Required]
        public BookingStatus BookingStatus { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        [ForeignKey("Car")]
        public string CarId { get; set; }
        public Car Car { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
        
    }
}
