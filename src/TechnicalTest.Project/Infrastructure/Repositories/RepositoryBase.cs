using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;


// Repository base class for DB operations 
// Inherited by Domain repository classes 
namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        protected TestDbContext _dbContext { get; set; }

        public RepositoryBase(TestDbContext context)
        {
            _dbContext = context;
        }

        // List all as per filter condition
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter);
        }

        // TODO
        // Get what? Come back to this later
        public async Task<T> GetAsync()
        {
            return (T)_dbContext.Set<T>().AsNoTracking();
        }

        // CRUD methods 
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        // Does not need to be asynchronous 
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        // Update the entity 
        public async Task<T> UpdateAsync(T entity)
        {
            var result = await UpdateAsync(entity);

            return result;
        }
    }
}
