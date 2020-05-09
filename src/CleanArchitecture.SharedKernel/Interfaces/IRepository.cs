using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedKernel.Interfaces
{
    public interface IRepository<TId>
    {
        Task<T> GetByIdAsync<T>(TId id) where T : BaseEntity<TId>;
        Task<List<T>> ListAsync<T>() where T : BaseEntity<TId>;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity<TId>;
        Task UpdateAsync<T>(T entity) where T : BaseEntity<TId>;
        Task DeleteAsync<T>(T entity) where T : BaseEntity<TId>;
    }
}