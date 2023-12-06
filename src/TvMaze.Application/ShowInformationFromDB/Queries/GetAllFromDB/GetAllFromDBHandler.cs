using AutoMapper;
using MediatR;
using TvMaze.Contracts.Output;
using TvMaze.Domain.Abstraction.Repositories;

namespace TvMaze.Application.ShowInformationFromDB.Queries.GetAllFromDB
{
    public class GetAllFromDBHandler : IRequestHandler<GetAllFromDBRequest, IEnumerable<ShowMainInformationDto>>
    {
        private readonly IShowMainInformationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllFromDBHandler(
            IShowMainInformationRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ShowMainInformationDto>> Handle(GetAllFromDBRequest request, CancellationToken cancellationToken)
        {
            var allData = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ShowMainInformationDto>>(allData);
        }
    }
}
