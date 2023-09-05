using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        Task CreateItemAsync(Item entity);
        Task DeleteItemAsync(Guid id);
        Task<IReadOnlyCollection<Item>> GetAllItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task UpdateItemAsync(Item entity);
    }
}