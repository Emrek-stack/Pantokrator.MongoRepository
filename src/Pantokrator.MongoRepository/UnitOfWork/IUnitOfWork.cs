using MongoDB.Driver;

namespace Pantokrator.MongoRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoDatabase CreateNewDatabase();
    }
}