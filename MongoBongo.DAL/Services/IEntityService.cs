using MongoBongo.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoBongo.DAL.Services
{
    public interface IEntityService<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, T entity);
    }
}