using AutoRent.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Interfaces
{
    public interface IFeatureService : IService<FeatureRequestDto, FeatureResponseDto>
    {
        /// <summary>
        /// Retrieves a feature entity from the database an converts it to a feature response dto
        /// transfer object
        /// </summary>
        /// <param name="id">ID of the object to be retrieved from the database</param>
        /// <returns>A data transfer object representing the domain entity</returns>
        public Task<FeatureResponseDto> GetAsync(string id);

        /// <summary>
        /// Retrieves all objects match TResponseDto from the database and 
        /// converts them to type TResponseDto
        /// </summary>
        /// <returns>A list of objects of type TResponseDto</returns>
        public Task<List<FeatureResponseDto>> GetAllAsync();
    }
}
