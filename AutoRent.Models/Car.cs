using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoRent.Models
{
    public class Car
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string DisplayName {
            get
            {
                return $"{Make} {Trim}";
            }
        }
        [Required]
        public decimal RentPricePerDay { get; set; }
        [Required]
        public List<string> Images { get; set; }
        [Required]
        [StringLength(10)]
        public string PlateNumber { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Trim { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public CarStatus Status { get; set; }

        [ForeignKey("Location")]
        public string LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }

    }
}
