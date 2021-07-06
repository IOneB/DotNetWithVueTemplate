using MongoBongo.DAL.Models;
using MongoBongo.Db.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoBongo.DAL.Services
{
    public class EntityService<T> : IEntityService<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        public EntityService(IWorkDbSettings settings, ICreateCollectionService createCollectionService)
        {
            _collection = createCollectionService.Create<T>(settings);
        }

        public async Task<List<T>> GetAsync()
        {
            var entities = await _collection.FindAsync(entity => true);
            return entities.ToList();
        }

        public async Task<T> GetAsync(string id)
        {
            var entity = await _collection.FindAsync(entity => entity.Id == id);
            return entity.FirstOrDefault();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public Task UpdateAsync(string id, T entity) => _collection.ReplaceOneAsync(entity => entity.Id == id, entity);

        public Task RemoveAsync(string id) => _collection.DeleteOneAsync(entity => entity.Id == id);
    }
}
