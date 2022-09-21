using AutoRent.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Interfaces
{
    public interface IUserService : IService<UserRequestInitialDto, UserResponseDto>
    {
        public Task CompleteRegistration(string id, UserRequestCompletionDto userRequestCompletionDto);
        public Task<UserResponseDto> GetUserById(string id);
        public Task<UserResponseDto> GetUserByEmail(string email);
        public Task<List<UserResponseDto>> GetAllUsers(string id);
        public Task<List<BookingResponseDto>> GetUserBookings(string id);
    }
}
