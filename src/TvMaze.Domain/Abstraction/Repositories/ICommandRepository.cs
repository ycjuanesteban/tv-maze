namespace TvMaze.Domain.Abstraction.Repositories
{
    public interface ICommandRepository<T>
    {
        Task AddAsync(T entity, CancellationToken cancellation = default);

        Task UpdateAsync(T entity, CancellationToken cancellation = default);
    }
}
