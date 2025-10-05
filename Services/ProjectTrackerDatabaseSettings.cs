namespace ProjectTracker.API.Services
{
    public class ProjectTrackerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string TasksCollectionName { get; set; } = null!;
    }
}