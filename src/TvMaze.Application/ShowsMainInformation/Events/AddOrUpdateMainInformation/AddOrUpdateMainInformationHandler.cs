using AutoMapper;
using MediatR;
using TvMaze.Domain;
using TvMaze.Domain.Abstraction.Repositories;

namespace TvMaze.Application.ShowsMainInformation.Events.AddOrUpdateMainInformation
{
    public class AddOrUpdateMainInformationHandler : INotificationHandler<AddOrUpdateMainInformationEvent>
    {
        private readonly IShowMainInformationRepository _repository;
        private readonly IMapper _mapper;

        public AddOrUpdateMainInformationHandler(
            IShowMainInformationRepository repository,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(AddOrUpdateMainInformationEvent notification, CancellationToken cancellationToken)
        {
            var showFound = await _repository.FindAsyn(notification.ShowInformation.Id, cancellationToken);

            if (showFound == null)
            {
                var showInformation = _mapper.Map<ShowMainInformation>(notification.ShowInformation);
                await _repository.AddAsync(showInformation, cancellationToken);
            }
            else
            {
                var showInformation = _mapper.Map(notification.ShowInformation, showFound);
                await _repository.UpdateAsync(showInformation, cancellationToken);
            }
        }
    }
}
