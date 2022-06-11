using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    }
}