using System.Linq.Expressions;
using MongoDB.Driver;

namespace Play.Common.MongoDB
{
    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        // private const string collectionName = "items";
        private readonly IMongoCollection<T> dbcollection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            /*var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Catalog");*/
            dbcollection = database.GetCollection<T>(collectionName);

        }

        public async Task<IReadOnlyCollection<T>> GetAllItemsAsync()
        {
            return await dbcollection.Find(filterBuilder.Empty).ToListAsync();
        }
        public async Task<T> GetItemAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);

            return await dbcollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateItemAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await dbcollection.InsertOneAsync(entity);
        }

        public async Task UpdateItemAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);


            await dbcollection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbcollection.DeleteOneAsync(filter);
        }

        public async Task<IReadOnlyCollection<T>> GetAllItemsAsync(Expression<Func<T, bool>> filter)
        {
            return await dbcollection.Find(filter).ToListAsync();
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> filter)
        {
            return await dbcollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}