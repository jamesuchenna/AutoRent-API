using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarRequestDto, Car>().ReverseMap();
            CreateMap<Car, CarResponseDto>().ReverseMap();
        }
    }
}
