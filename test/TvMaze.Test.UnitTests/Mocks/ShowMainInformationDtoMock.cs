using TvMaze.Contracts.Output;

namespace TvMaze.Test.UnitTests.Mocks
{
    public static class ShowMainInformationDtoMock
    {
        public static ShowMainInformationDto ShowOneWithNotCast()
        {
            return new ShowMainInformationDto()
            {
                Id = 1,
                Url = "https://www.tvmaze.com/shows/1/under-the-dome",
                Name = "Under the Dome",
                Type = "Scripted",
                Language = "English",
                Genres = new List<string>() { "Drama", "Thriller" },
                Status = "Ended",
                Runtime = 60,
                AverageRuntime = 60,
                Premiered = "2013-06-24",
                Ended = "2015-09-10",
                OfficialSite = "http://www.cbs.com/shows/under-the-dome/",
                Schedule = new ScheduleDto()
                {
                    Days = new List<string>() { "Thursday" },
                    Time = "22:00"
                },
                Rating = new RatingDto() { Average = 6.5 },
                Weight = 99,
                Network = new NetworkDto()
                {
                    Id = 2,
                    Name = "CBS",
                    Country = new CountryDto()
                    {
                        Code = "US",
                        Name = "United States",
                        Timezone = "America/NewYork"
                    },
                    OfficialSite = "https://www.cbs.com/"
                },
                Image = new ImageDto()
                {
                    Medium = "https://static.tvmaze.com/uploads/images/medium_portrait/81/202627.jpg",
                    Original = "https://static.tvmaze.com/uploads/images/original_untouched/81/202627.jpg"
                }
            };
        }

        public static ShowMainInformationDto ShowOneWithCast()
        {
            var showOne = ShowOneWithNotCast();
            showOne.Embedded = new EmbeddedDto()
            {
                Cast = new List<CastDto> {
                    new CastDto()
                    {
                        Person = new PersonDto()
                        {
                            Id = 1,
                            Url = "https://www.tvmaze.com/people/1/mike-vogel",
                            Name = "Mike Vogel",
                            Country = new CountryDto()
                            {
                                Name = "United States",
                                Code = "US",
                                Timezone = "America/New_York"
                            },
                            Birthday = "1979-07-17"
                        },
                        Character = new CharacterDto()
                        {
                            Id = 1,
                            Name = "Dale \"Barbie\" Barbara",
                        }
                    }
                }
            };
            return showOne;
        }
    }
}
