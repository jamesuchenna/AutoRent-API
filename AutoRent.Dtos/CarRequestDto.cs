using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class CarRequestDto
    {
        public decimal RentPricePerDay { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string LocationId { get; set; }
        public int Mileage { get; set; }
        public List<string> Images { get; set; }
    }
}
