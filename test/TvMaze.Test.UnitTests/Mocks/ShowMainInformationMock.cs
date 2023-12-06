using TvMaze.Contracts.Output;
using TvMaze.Domain;

namespace TvMaze.Test.UnitTests.Mocks
{
    public static class ShowMainInformationMock
    {
        public static ShowMainInformation ShowOneWithNotCast()
        {
            return new ShowMainInformation()
            {
                ShowInformationId = "65704241d61c6ec4f403275a",
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
                Schedule = new Schedule()
                {
                    Days = new List<string>() { "Thursday" },
                    Time = "22:00"
                },
                Rating = new Rating() { Average = 6.5 },
                Weight = 99,
                Network = new Network()
                {
                    Name = "CBS",
                    Country = new Country()
                    {
                        Code = "US",
                        Name = "United States",
                        Timezone = "America/NewYork"
                    },
                    OfficialSite = "https://www.cbs.com/"
                },
                Image = new Image()
                {
                    Medium = "https://static.tvmaze.com/uploads/images/medium_portrait/81/202627.jpg",
                    Original = "https://static.tvmaze.com/uploads/images/original_untouched/81/202627.jpg"
                }
            };
        }
    }
}
