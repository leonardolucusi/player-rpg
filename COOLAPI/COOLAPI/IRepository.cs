namespace COOLAPI
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long? id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
    }
}
