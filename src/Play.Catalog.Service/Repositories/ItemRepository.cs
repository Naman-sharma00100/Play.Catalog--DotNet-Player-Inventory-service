using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> dbcollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public ItemsRepository(IMongoDatabase database)
        {
            /*var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Catalog");*/
            dbcollection = database.GetCollection<Item>(collectionName);

        }

        public async Task<IReadOnlyCollection<Item>> GetAllItemsAsync()
        {
            return await dbcollection.Find(filterBuilder.Empty).ToListAsync();
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, id);

            return await dbcollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateItemAsync(Item entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await dbcollection.InsertOneAsync(entity);
        }

        public async Task UpdateItemAsync(Item entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            FilterDefinition<Item> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);


            await dbcollection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbcollection.DeleteOneAsync(filter);
        }


    }
}