using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechnicalTest.Project.Pagination;

namespace TechnicalTest.Project.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        // Get all method based on filter params
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);


        // CRUD Methods 
        Task<T> GetAsync();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        void Delete(T entity);


        // LINQ extension methods 
        Task<T> GetEntityAndRelationsAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetEntityListPaginatedAsync(Expression<Func<T, bool>> filter, PaginationModel pg);
        Task<int> CountByExprAsync(Expression<Func<T, bool>> filter);
    }
}