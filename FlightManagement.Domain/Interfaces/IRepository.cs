using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
