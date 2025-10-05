using MongoDB.Driver;
using ProjectTracker.API.Models;
using Microsoft.Extensions.Options;

namespace ProjectTracker.API.Services
{
    public class TaskService
    {
        private readonly IMongoCollection<TaskItem> _tasksCollection;

        public TaskService(IOptions<ProjectTrackerDatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _tasksCollection = mongoDatabase.GetCollection<TaskItem>(dbSettings.Value.TasksCollectionName);
        }

        public async Task<List<TaskItem>> GetAsync() =>
            await _tasksCollection.Find(_ => true).ToListAsync();

        public async Task<TaskItem?> GetAsync(string id) =>
            await _tasksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TaskItem newTask) =>
            await _tasksCollection.InsertOneAsync(newTask);

        public async Task UpdateAsync(string id, TaskItem updatedTask) =>
            await _tasksCollection.ReplaceOneAsync(x => x.Id == id, updatedTask);

        public async Task RemoveAsync(string id) =>
            await _tasksCollection.DeleteOneAsync(x => x.Id == id);
    }
}