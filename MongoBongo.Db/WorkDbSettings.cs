namespace MongoBongo.Db.Settings
{
    public interface IWorkDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string WorksCollectionName { get; set; }
    }

    public class WorkDbSettings : IWorkDbSettings
    {
        public string WorksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
