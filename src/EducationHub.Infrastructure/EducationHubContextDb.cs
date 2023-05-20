using EducationHub.Business.Entities;
using EducationHub.Shared.Environment;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace EducationHub.Infrastructure;

public class EducationHubContextDb
{
    public IMongoDatabase Database { get; }

    public EducationHubContextDb()
    {
        try
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(Settings.ConnectionString));
            var client = new MongoClient(settings);
            Database = client.GetDatabase(Settings.Database);
            MapClasses();
        }
        catch (Exception ex)
        {
            throw new MongoException("It was not possible to connect to MongoDB", ex);
        }
    }

    private void MapClasses()
    {
        var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
        {
            BsonClassMap.RegisterClassMap<User>(i =>
            {
                i.AutoMap();
                i.SetIgnoreExtraElements(true);
            });
        }
    }
}