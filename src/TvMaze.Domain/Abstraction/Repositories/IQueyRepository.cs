namespace TvMaze.Domain.Abstraction.Repository
{
    public interface IQueyRepository<T>
    {
        Task<T> FindAsyn(int Id, CancellationToken cancellation = default);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellation = default);
    }
}
