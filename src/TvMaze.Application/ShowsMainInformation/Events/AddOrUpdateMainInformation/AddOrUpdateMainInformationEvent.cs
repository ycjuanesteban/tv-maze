using MediatR;
using TvMaze.Contracts.Output;

namespace TvMaze.Application.ShowsMainInformation.Events.AddOrUpdateMainInformation
{
    public class AddOrUpdateMainInformationEvent : INotification
    {
        public ShowMainInformationDto ShowInformation { get; set; }

        public AddOrUpdateMainInformationEvent(ShowMainInformationDto showMainInformation)
        {
            ShowInformation = showMainInformation;
        }
    }
}
