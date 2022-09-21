using AutoRent.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AutoRentDbContext _dbContext;
        private readonly DbSet<T> _entitySet;

        public GenericRepository(AutoRentDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = dbContext.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await _entitySet.AddAsync(item);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _entitySet.FindAsync(id);
            _entitySet.Remove(entity);
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _entitySet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return _entitySet.AsNoTracking().ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _entitySet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Update(T item)
        {
            // attaches instance to the contex
            // t, then sets the state
            // as modified
            _dbContext.Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
