using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentRequestDto, Payment>().ReverseMap();
            CreateMap<Payment, PaymentResponseDto>().ReverseMap();
        }
    }
}
