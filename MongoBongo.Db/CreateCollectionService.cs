using MongoDB.Driver;

namespace MongoBongo.Db.Settings
{
    public interface ICreateCollectionService
    {
        IMongoCollection<T> Create<T>(IWorkDbSettings settings);
    }

    public class CreateCollectionService : ICreateCollectionService
    {
        public IMongoCollection<T> Create<T>(IWorkDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            return database.GetCollection<T>(settings.WorksCollectionName);
        }
    }
}
