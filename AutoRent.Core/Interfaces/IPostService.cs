using AutoRent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Interfaces
{
    public interface IPostService : IService<PostRequestDto, PostResponseDto>
    {
    }
}

