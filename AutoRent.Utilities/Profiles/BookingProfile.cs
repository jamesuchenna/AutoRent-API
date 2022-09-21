using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingRequestDto, Booking>().ReverseMap();
            CreateMap<Booking, BookingResponseDto>().ReverseMap();
        }
    }
}
