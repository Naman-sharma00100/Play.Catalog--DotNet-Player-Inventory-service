using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateItemAsync(T entity);
        Task DeleteItemAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllItemsAsync();
        Task<T> GetItemAsync(Guid id);
        Task UpdateItemAsync(T entity);
    }
}