using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Core.Interfaces
{
    public interface IService<TRequestDto, TResponseDto>
    {
        /// <summary>
        /// Converts a data transfer object of type TRequestDto
        /// to a domain entity object to be stored in the database
        /// </summary>
        /// <param name="item">Data transfer object representing the domain entity</param>
        /// <returns></returns>
        public Task AddAsync(TRequestDto item);

        /// <summary>
        /// Converts a data transfer object of type TRequestDto
        /// to a matching domain entity object to be updated in the database
        /// </summary>
        /// <param name="id">ID of ddomain entity object to be retrieved from the database and updated</param>
        /// <param name="item">Data transfer object representing the domain entity</param>
        /// <returns></returns>
        public Task Update(string id, TRequestDto item);

        /// <summary>
        /// Deletes a domain entity object from the database
        /// </summary>
        /// <param name="id">ID of the object to be deleted from the database</param>
        /// <returns></returns>
        public Task DeleteAsync(string id);

    }
}
