namespace MongoBongo.Models.Config
{
    public interface IWorkDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string WorksCollectionName { get; set; }
    }
}