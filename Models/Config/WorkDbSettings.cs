namespace MongoBongo.Models.Config
{
    public class WorkDbSettings : IWorkDbSettings
    {
        public string WorksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
