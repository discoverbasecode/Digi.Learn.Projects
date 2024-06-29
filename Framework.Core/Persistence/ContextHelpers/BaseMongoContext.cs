using MongoDB.Driver;

namespace Framework.Core.Persistence.ContextHelpers;

public abstract class BaseMongoContext(MongoSettings settings, IMongoClient client)
{
    private readonly IMongoDatabase _database = client.GetDatabase(settings.DatabaseName);
    public IMongoDatabase GetDataBase() { return _database; }
}