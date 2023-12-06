using MediatR;
using TvMaze.Contracts.Output;

namespace TvMaze.Application.ShowsMainInformation.Queries.GetShowMainInformation
{
    public class GetShowMainInformationRequest : IRequest<ShowMainInformationDto>
    {
        public int ShowId { get; set; }
        public bool WithEmbedCast { get; set; }
    }
}
