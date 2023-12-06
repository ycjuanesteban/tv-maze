using TvMaze.Domain.Abstraction.Repository;

namespace TvMaze.Domain.Abstraction.Repositories
{
    public interface IShowMainInformationRepository :
        IQueyRepository<ShowMainInformation>,
        ICommandRepository<ShowMainInformation>
    {
    }
}
