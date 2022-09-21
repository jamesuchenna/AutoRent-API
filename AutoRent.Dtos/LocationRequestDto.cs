using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class LocationRequestDto
    {
        public string StreetNumber { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}
