using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;
using TechnicalTest.Project.Pagination;


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
        // Update: A singleton object is the return type but no parameters to 
        // define what to get, perhaps just return the first object?
        public async Task<T> GetAsync()
        {
            throw new NotImplementedException();
        }

        // CRUD methods 
        // Create
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        // Does not need to be asynchronous 
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        // Update the entity 
        public async Task<T> UpdateAsync(T entity)
        {

            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }


        // LINQ extensions

        // Get a count of entities based on a filter
        public async Task<int> CountByExprAsync(Expression<Func<T, bool>> filter)
        {
            // Get enumerable list of items as per filter
            var items = _dbContext.Set<T>().Where(filter);

            return items.Count();
        }

        // Get an entity and all of its relationships
        public async Task<T> GetEntityAndRelationsAsync(Expression<Func<T, bool>> filter)
        {

            // TODO
            // Get entity as per filter
            // Grab related objects
            // Return json object

            // Will most likely need to implement this method in each Domain repo
            // since each domain has its own specific relationships

            // Will also need to find a way to return a response type of both
            // the entity and the related objects as a list perhaps (?)

            // Do research and come back to this later

            // Update: Using LINQ queries to grab nested relationships using .Include,
            // still unable to determine how to return both the entity and the nested
            // queries as a single response or what to change this funcs return type to,
            // perhaps a custom DTO or custom JSON response

            throw new NotImplementedException();
        }

        // Get a list of entities paginated
        public async Task<IEnumerable<T>> GetEntityListPaginatedAsync(Expression<Func<T, bool>> filter, PaginationModel @params)
        {

            // Get entity list as per filter and then perform pagination 
            var entityList = await _dbContext.Set<T>().Where(filter)
                            .Skip((@params.Page - 1) * @params.PageSize)
                            .Take(@params.PageSize)
                            .ToListAsync();

            return entityList;
        }
    }
}
