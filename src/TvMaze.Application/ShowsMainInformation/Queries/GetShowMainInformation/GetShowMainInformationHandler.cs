using MediatR;
using TvMaze.Application.ShowsMainInformation.Events.AddOrUpdateMainInformation;
using TvMaze.Contracts;
using TvMaze.Contracts.Output;

namespace TvMaze.Application.ShowsMainInformation.Queries.GetShowMainInformation
{
    public class GetShowMainInformationHandler : IRequestHandler<GetShowMainInformationRequest, ShowMainInformationDto>
    {
        private readonly ITvMazeServiceClient _tvMazeClient;
        private readonly IMediator _mediator;

        public GetShowMainInformationHandler(
            ITvMazeServiceClient tvMazeClient,
            IMediator mediator)
        {
            _tvMazeClient = tvMazeClient ?? throw new ArgumentNullException(nameof(tvMazeClient));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ShowMainInformationDto> Handle(GetShowMainInformationRequest request, CancellationToken cancellationToken)
        {
            var apiShowInformation = await _tvMazeClient.GetShowInformation(request.ShowId, request.WithEmbedCast, cancellationToken);

            await _mediator.Publish(new AddOrUpdateMainInformationEvent(apiShowInformation));

            return apiShowInformation;
        }
    }
}
