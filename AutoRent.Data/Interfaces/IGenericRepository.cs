using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Adds an object of type T to the database context
        /// </summary>
        /// <param name="item">Object of type T to be added to database context</param>
        /// <returns></returns>
        public Task AddAsync(T item);

        /// <summary>
        /// Retrieves an object of type T from the database context
        /// </summary>
        /// <param name="id">ID of the object to be retrieved from the database context</param>
        /// <returns></returns>
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes=null);

        /// <summary>
        /// Retrieves all objects of type T from the database context
        /// </summary>
        /// <returns>A list of all objects of type T in the database context</returns>
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null);

        /// <summary>
        /// Updates the value of an object of type T in the database context
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(T item);

        /// <summary>
        /// Deletes an object of type T from the database context
        /// </summary>
        /// <param name="id">ID of the object to be deleted from the database context</param>
        /// <returns></returns>
        public Task DeleteAsync(string id);
    }
}
