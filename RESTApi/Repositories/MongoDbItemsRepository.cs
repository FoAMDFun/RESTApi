using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using RESTApi.Entities;

namespace RESTApi.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        //private const string databaseName = "RestAPI";
        private const string collecionName = "items";
        
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoDatabase mongoDatabase)
        {
            IMongoDatabase database = mongoDatabase;
            itemsCollection = database.GetCollection<Item>(collecionName);
        }
        public async Task CreateItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }
        
        public async Task DeleteItemAsync(Guid id)
        {
            await itemsCollection.DeleteOneAsync(item => item.Id == id);
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            return await itemsCollection.Find(item => item.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.Find(item => true).ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            await itemsCollection.ReplaceOneAsync(filter => filter.Id == item.Id, item);
        }
    }
}
