using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Interfaces;

public interface IRepository<T> where T : class, IAggregate
{
    Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    void Add(T entity);
    void Delete(T entity);
}