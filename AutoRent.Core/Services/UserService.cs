using AutoMapper;
using AutoRent.Core.Interfaces;
using AutoRent.Data.Interfaces;
using AutoRent.Dtos;
using AutoRent.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ILogger logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(UserRequestInitialDto userRequestInitialDto)
        {
            var user = _mapper.Map<User>(userRequestInitialDto);

            if (user == null)
            {
                _logger.LogInformation("User DTO did not map to User: Invalid credentials provided for user registeration");
                throw new Exception("One or more of your inputs are incorrect");
            }

            user.Verified = false;
            user.Id = Guid.NewGuid().ToString();
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            {
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.Save();

                _logger.LogInformation($"User registration for {user.Email} was successful");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"User details correct but could not add user to database: {ex.Message}");
                throw new Exception("One or more errors occured during your registration");
            }
        }

        public async Task CompleteRegistration(string id, UserRequestCompletionDto userRequestCompletionDto)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id);
            user.HomeAddress = userRequestCompletionDto.HomeAddress;
            user.NextOfKinName = userRequestCompletionDto.NextOfKinName;
            user.NextOfKinAddress = userRequestCompletionDto.NextOfKinAddress;
            user.NextOfKinContact = userRequestCompletionDto.NextOfKinContact;
            user.DrivingLicenceImage = userRequestCompletionDto.DrivingLicenceImage;
            user.UserImageUrl = userRequestCompletionDto.UserImageUrl;
            user.CompletedRegistration = true;
            user.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.Save();
                _logger.LogInformation($"Updated user {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update user {id} information: {ex.Message}");
                throw new Exception("Could not update user information");
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _unitOfWork.UserRepository.DeleteAsync(id);
                await _unitOfWork.Save();
                _logger.LogInformation($"Successfully deleted user {id} from database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete user {id} from database: {ex.Message}");
                throw new Exception($"Could not delete user {id} from database");
            }
        }

        public async Task<List<UserResponseDto>> GetAllUsers(string id)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<List<BookingResponseDto>> GetUserBookings(string id)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync(b => b.UserId == id);
            return _mapper.Map<List<BookingResponseDto>>(bookings);
        }

        public async Task<UserResponseDto> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == email);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> GetUserById(string id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task Update(string id, UserRequestInitialDto userRequestInitialDto)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id);
            user.FirstName = userRequestInitialDto.FirstName;
            user.LastName = userRequestInitialDto.LastName;
            user.Email = userRequestInitialDto.Email;
            user.PhoneNumber = userRequestInitialDto.PhoneNumber;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRequestInitialDto.Password);
            user.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.Save();
                _logger.LogInformation($"Updated user {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update user {id} information: {ex.Message}");
                throw new Exception("Could not update user information");
            }
        }
    }
}
