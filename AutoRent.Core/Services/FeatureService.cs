using AutoMapper;
using AutoRent.Core.Interfaces;
using AutoRent.Data.Interfaces;
using AutoRent.Dtos;
using AutoRent.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public FeatureService(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task AddAsync(FeatureRequestDto featureRequestDto)
        {
            var feature = _mapper.Map<Feature>(featureRequestDto);

            feature.Id = Guid.NewGuid().ToString();
            feature.CreatedAt = DateTime.Now;
            feature.UpdatedAt = DateTime.Now;

            if (feature == null)
            {
                _logger.LogInformation("Feature Dto did not map. Invalid details");
                throw new Exception("One or more of your inputs are incorrect.");
            }

            try
            {
                await _unitOfWork.FeatureRepository.AddAsync(feature);
                await _unitOfWork.Save();
                _logger.LogInformation("Feature was successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Feature was not added {ex.Message}.");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _unitOfWork.FeatureRepository.DeleteAsync(id);
                await _unitOfWork.Save();
                _logger.LogInformation($"Feature with Id: {id} was successfully deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured.Feature was not deleted {ex.Message}.");
                throw;
            }
        }

        public async Task<List<FeatureResponseDto>> GetAllAsync()
        {
            try
            {
                var features = await _unitOfWork.FeatureRepository.GetAllAsync();
                await _unitOfWork.Save();
                _logger.LogInformation("All features successfully retrieved");
                return _mapper.Map<List<FeatureResponseDto>>(features);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Unable to retrieve all features {ex.Message}.");
                throw;
            }
        }

        public async Task<FeatureResponseDto> GetAsync(string id)
        {
            try
            {
                var feature = await _unitOfWork.FeatureRepository.GetAsync(c => c.Id == id);
                await _unitOfWork.Save();
                _logger.LogInformation("All features successfully retrieved");
                return _mapper.Map<FeatureResponseDto>(feature);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Feature with Id: {id} not found {ex.Message}.");
                throw;
            }
        }

        public async Task Update(string Id, FeatureRequestDto featureResquestDto)
        {
            var feature = await _unitOfWork.FeatureRepository.GetAsync(x => x.Id == Id);
            feature.IconUrl = featureResquestDto.IconUrl;
            feature.Name = featureResquestDto.Name;
            feature.IconUrl = featureResquestDto.IconUrl;
            feature.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.FeatureRepository.Update(feature);
                await _unitOfWork.Save();
                _logger.LogInformation($"Feature with Id: {Id} was successfully saved.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occured. Feature with Id: {Id} was not updated {ex.Message}.");
                throw;
            }
        }
    }
}
