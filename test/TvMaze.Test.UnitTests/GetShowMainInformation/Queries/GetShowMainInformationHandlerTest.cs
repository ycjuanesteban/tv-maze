using FluentAssertions;
using MediatR;
using Moq;
using System.Net;
using TvMaze.Application.ShowsMainInformation.Events.AddOrUpdateMainInformation;
using TvMaze.Application.ShowsMainInformation.Queries.GetShowMainInformation;
using TvMaze.Contracts;
using TvMaze.Test.UnitTests.Mocks;

namespace TvMaze.Test.UnitTests.GetShowMainInformation.Queries
{
    public class GetShowMainInformationHandlerTest
    {
        private readonly Mock<ITvMazeServiceClient> _tvMazeClient;
        private readonly Mock<IMediator> _mediator;

        public GetShowMainInformationHandlerTest()
        {
            _tvMazeClient = new Mock<ITvMazeServiceClient>();
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Handler_Should_ReturnDataFromApi_WhenSendAnExistentShowId()
        {
            // Arrange
            _tvMazeClient.Setup(x => x.GetShowInformation(1, false, default))
                .ReturnsAsync(ShowMainInformationDtoMock.ShowOneWithNotCast());

            var request = new GetShowMainInformationRequest() { ShowId = 1 };

            var handle = new GetShowMainInformationHandler(_tvMazeClient.Object, _mediator.Object);

            // Act

            var response = await handle.Handle(request, default);

            // Assert

            Assert.NotNull(response);
            response.Url.Should().Be("https://www.tvmaze.com/shows/1/under-the-dome");
            response.Name.Should().Be("Under the Dome");
            response.Runtime.Should().Be(60);
            response.Genres.Should().HaveCount(2);
            response.Schedule.Should().NotBeNull();

        }

        [Fact]
        public async Task Handler_Should_ReturnDataFromApi_WhenSendAnExistentShowIdAndEmbbedCastToTrue()
        {
            // Arrange
            _tvMazeClient.Setup(x => x.GetShowInformation(1, true, default))
                .ReturnsAsync(ShowMainInformationDtoMock.ShowOneWithCast());

            var request = new GetShowMainInformationRequest() { ShowId = 1, WithEmbedCast = true };

            var handle = new GetShowMainInformationHandler(_tvMazeClient.Object, _mediator.Object);

            // Act

            var response = await handle.Handle(request, default);

            // Assert

            Assert.NotNull(response);
            response.Runtime.Should().Be(60);
            response.Genres.Should().HaveCount(2);
            response.Schedule.Should().NotBeNull();
            response.Embedded.Should().NotBeNull();
            response.Embedded.Cast.Should().NotBeNull();
            response.Embedded.Cast.Should().HaveCount(1);
        }

        [Fact]
        public async Task Handler_Should_Return404Error_WhenSendANotExistentShowId()
        {
            // Arrange
            _tvMazeClient.Setup(x => x.GetShowInformation(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new HttpRequestException("Not found", null, statusCode: HttpStatusCode.NotFound));

            var request = new GetShowMainInformationRequest() { ShowId = 99999999, WithEmbedCast = true };

            var handle = new GetShowMainInformationHandler(_tvMazeClient.Object, _mediator.Object);

            // Act

            Func<Task> action = async () => await handle.Handle(request, default);

            // Assert
            action.Should().ThrowAsync<HttpRequestException>();
            action.Should().ThrowAsync<HttpRequestException>().WithMessage("Not found");
        }

        [Fact]
        public async Task Handler_Should_ReturnException_WhenMediatorPublishThrowException()
        {
            // Arrange
            _tvMazeClient.Setup(x => x.GetShowInformation(1, false, default))
                 .ReturnsAsync(ShowMainInformationDtoMock.ShowOneWithNotCast());

            _mediator.Setup(x => x.Publish(new AddOrUpdateMainInformationEvent(new Contracts.Output.ShowMainInformationDto()), default))
                .ThrowsAsync(new Exception());

            var request = new GetShowMainInformationRequest() { ShowId = 1 };

            var handle = new GetShowMainInformationHandler(_tvMazeClient.Object, _mediator.Object);

            // Act

            Func<Task> action = async () => await handle.Handle(request, default);

            // Assert
            action.Should().ThrowAsync<Exception>();
        }
    }
}
