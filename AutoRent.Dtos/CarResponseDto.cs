using AutoRent.Models;
using AutoRent.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class CarResponseDto
    {
        public string Id { get; set; }
        public decimal RentPricePerDay { get; set; }
        public string DisplayName
        {
            get
            {
                // edit later tp display short name
                return $"{Make} {Trim}";
            }
        }
        public LocationResponseDto LocationResponseDto { get; set; }
        public List<string> Images { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Mileage { get; set; }
        public CarStatus Status { get; set; }
        // edit when CarFeature model is created

        public List<BookingResponseDto> Bookings { get; set; }
    }
}
