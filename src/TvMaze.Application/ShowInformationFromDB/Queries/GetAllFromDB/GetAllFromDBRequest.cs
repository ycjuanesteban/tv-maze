using MediatR;
using TvMaze.Contracts.Output;

namespace TvMaze.Application.ShowInformationFromDB.Queries.GetAllFromDB
{
    public class GetAllFromDBRequest : IRequest<IEnumerable<ShowMainInformationDto>>
    {
    }
}
