using AutoMapper;
using AutoRent.Dtos;
using AutoRent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRent.Utilities.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<PostRequestDto, Post>().ReverseMap();
            CreateMap<Post, PostResponseDto>().ReverseMap();
        }
    }
}
