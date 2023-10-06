namespace SimpleStore.Api.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);        
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
    }
}
