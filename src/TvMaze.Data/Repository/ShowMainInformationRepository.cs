using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TvMaze.Domain;
using TvMaze.Domain.Abstraction.Repositories;

namespace TvMaze.Data.Repository
{
    public class ShowMainInformationRepository : IShowMainInformationRepository
    {
        private readonly IMongoCollection<ShowMainInformation> _showsCollection;

        public ShowMainInformationRepository(IOptions<TvMazeContextConfigOptions> optionsSettings)
        {
            var mongoClient = new MongoClient(optionsSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(optionsSettings.Value.DatabaseName);

            _showsCollection = mongoDatabase.GetCollection<ShowMainInformation>(optionsSettings.Value.CollectionName);
        }

        public async Task AddAsync(ShowMainInformation entity, CancellationToken cancellation = default)
        {
            await _showsCollection.InsertOneAsync(entity, cancellation);
        }

        public async Task<ShowMainInformation> FindAsyn(int Id, CancellationToken cancellation = default)
        {
            return await _showsCollection
                .Find(x => x.Id == Id)
                .FirstOrDefaultAsync(cancellation);
        }

        public async Task<IEnumerable<ShowMainInformation>> GetAllAsync(CancellationToken cancellation = default)
        {
            return await _showsCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(ShowMainInformation entity, CancellationToken cancellation = default)
        {
            await _showsCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions()
            {
                IsUpsert = true,
            }, cancellation);
        }
    }
}
