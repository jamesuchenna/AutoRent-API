using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestInitialDto, User>().ReverseMap();
            CreateMap<UserRequestCompletionDto, User>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
        }
    }
}
