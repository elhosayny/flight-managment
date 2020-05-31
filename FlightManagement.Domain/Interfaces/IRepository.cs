using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
