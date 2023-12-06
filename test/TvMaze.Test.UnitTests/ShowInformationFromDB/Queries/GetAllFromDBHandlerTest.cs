using AutoMapper;
using FluentAssertions;
using Moq;
using TvMaze.Application.Mappers;
using TvMaze.Application.ShowInformationFromDB.Queries.GetAllFromDB;
using TvMaze.Contracts.Output;
using TvMaze.Domain;
using TvMaze.Domain.Abstraction.Repositories;
using TvMaze.Test.UnitTests.Mocks;

namespace TvMaze.Test.UnitTests.ShowInformationFromDB.Queries
{
    public class GetAllFromDBHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShowMainInformationRepository> _repository;

        public GetAllFromDBHandlerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GenericMappers());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _repository = new Mock<IShowMainInformationRepository>();
        }

        [Fact]
        public async Task Handler_Should_ReturnAListOfShows()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(new List<ShowMainInformation>() { ShowMainInformationMock.ShowOneWithNotCast() });

            var request = new GetAllFromDBRequest();

            var handler = new GetAllFromDBHandler(_repository.Object, _mapper);

            // Act

            var response = await handler.Handle(request, default);

            // Assert

            Assert.NotNull(response);
            response.Should().HaveCount(1);
            response.ToList()[0].Should().BeOfType(typeof(ShowMainInformationDto));
        }


        [Fact]
        public async Task Handler_Should_ReturnZeroShows()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(new List<ShowMainInformation>() { });

            var request = new GetAllFromDBRequest();

            var handler = new GetAllFromDBHandler(_repository.Object, _mapper);

            // Act

            var response = await handler.Handle(request, default);

            // Assert

            Assert.NotNull(response);
            response.Should().HaveCount(0);
        }
    }
}
