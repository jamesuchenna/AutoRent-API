using AutoMapper;
using AutoRent.Core.Interfaces;
using AutoRent.Data.Interfaces;
using AutoRent.Dtos;
using AutoRent.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoRent.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task AddAsync(CarRequestDto carRequestDto)
        {
            var car = _mapper.Map<Car>(carRequestDto);

            car.Id = Guid.NewGuid().ToString();
            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            if(car == null)
            {
                _logger.LogInformation("Car Dto did not map. Invalid details");
                throw new Exception("One or more of your inputs are incorrect");
            }

            try
            {
                await _unitOfWork.CarRepository.AddAsync(car);
                await _unitOfWork.Save();
                _logger.LogInformation("Car successfully added");
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"An error occured, car was not added {ex.Message}.");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _unitOfWork.CarRepository.DeleteAsync(id);
                await _unitOfWork.Save();
                _logger.LogInformation("Car was successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"an error occured, car was not deleted {ex.Message}.");
                throw;
            }
        }

        public async Task<List<CarResponseDto>> GetAllAsync()
        {
            try
            {
                var cars = await _unitOfWork.CarRepository.GetAllAsync();
                await _unitOfWork.Save();
                _logger.LogInformation("All Cars were successfully retrieved");
                return _mapper.Map<List<CarResponseDto>>(cars);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Cars were not successfully retrieved {ex.Message}.");
                throw;
            }
        }

        public async Task<CarResponseDto> GetAsync(string id)
        {
            try
            {
                var car = await _unitOfWork.CarRepository.GetAsync(x => x.Id == id);
                await _unitOfWork.Save();
                _logger.LogInformation($"Car with Id:{id} was successfully retrieved");
                return _mapper.Map<CarResponseDto>(car);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Car with Id:{id} was not successfully retrieved {ex.Message}.");
                throw;
            }
        }

        public async Task Update(string id, CarRequestDto carRequestDto)
        {
            var car = await _unitOfWork.CarRepository.GetAsync(x => x.Id == id);
            car.LocationId = carRequestDto.LocationId;
            car.RentPricePerDay = carRequestDto.RentPricePerDay;
            car.Make = carRequestDto.Make;
            car.Model = carRequestDto.Model;
            car.Trim = carRequestDto.Trim;
            car.Mileage = carRequestDto.Mileage;
            car.Images = carRequestDto.Images;
            car.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.CarRepository.Update(car);
                await _unitOfWork.Save();
                _logger.LogInformation("Car was successfully updated.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Car was not updated {ex.Message}.");
                throw;
            }
        }
    }
}
