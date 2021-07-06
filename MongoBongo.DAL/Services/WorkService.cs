using MongoBongo.DAL.Models.Entities;
using MongoBongo.Db.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoBongo.DAL.Services
{
    public class WorkService : IEntityService<Work>
    {
        private readonly IMongoCollection<Work> _works;

        public WorkService(IWorkDbSettings settings, ICreateCollectionService createCollectionService)
        {
            _works = createCollectionService.Create<Work>(settings);
        }

        public async Task<List<Work>> GetAsync()
        {
            var works = await _works.FindAsync(work => true);
            return works.ToList();
        }

        public async Task<Work> GetAsync(string id)
        {
            var work = await _works.FindAsync(work => work.Id == id);
            return work.FirstOrDefault();
        }

        public async Task<Work> CreateAsync(Work work)
        {
            await _works.InsertOneAsync(work);
            return work;
        }

        public Task UpdateAsync(string id, Work work) => _works.ReplaceOneAsync(work => work.Id == id, work);

        public Task RemoveAsync(string id) => _works.DeleteOneAsync(work => work.Id == id);
    }
}
