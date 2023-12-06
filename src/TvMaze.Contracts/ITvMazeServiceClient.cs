using TvMaze.Contracts.Output;

namespace TvMaze.Contracts
{
    public interface ITvMazeServiceClient
    {
        Task<ShowMainInformationDto> GetShowInformation(int id, bool withCast = false, CancellationToken cancellationToken = default);
    }
}
