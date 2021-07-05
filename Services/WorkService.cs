using MongoBongo.Models;
using MongoBongo.Models.Config;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoBongo.Services
{
    public class WorkService
    {
        private readonly IMongoCollection<Work> _works;

        public WorkService(IWorkDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _works = database.GetCollection<Work>(settings.WorksCollectionName);
        }

        public List<Work> Get() => _works.Find(work => true).ToList();

        public Work Get(string id) => _works.Find(work => work.Id == id).FirstOrDefault();

        public Work Create(Work work)
        {
            _works.InsertOne(work);
            return work;
        }

        public void Update(string id, Work work) => _works.ReplaceOne(work => work.Id == id, work);

        public void Remove(string id) => _works.DeleteOne(work => work.Id == id);
    }
}
