using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Dtos
{
    public class LocationResponseDto
    {
		public string Id { get; set; }
		public string Name
		{
			get { return $"{Area}, {State}"; }
		}
		public string Area { get; set; }
		public string State { get; set; }
		public string Street { get; set; }
		public string PhoneNumber { get; set; }
		public List<CarResponseDto> Cars { get; set; }

	}
}
