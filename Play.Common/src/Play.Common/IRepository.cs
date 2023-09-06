
using System.Linq.Expressions;

namespace Play.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateItemAsync(T entity);
        Task DeleteItemAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllItemsAsync();

        Task<IReadOnlyCollection<T>> GetAllItemsAsync(Expression<Func<T, bool>> filter);

        Task<T> GetItemAsync(Guid id);

        Task<T> GetItemAsync(Expression<Func<T, bool>> filter);

        Task UpdateItemAsync(T entity);
    }
}