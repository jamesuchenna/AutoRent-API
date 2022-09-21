using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationRequestDto, Location>().ReverseMap();
            CreateMap<Location, LocationResponseDto>().ReverseMap();
        }
    }
}
