using Bot.persistence.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;

namespace Bot.persistence.MongoDb.Configurations;

public class UserCollectionConfigurator : ICollectionConfigurator
{
    public void ConfigureCollection()
    {
        if(BsonClassMap.IsClassMapRegistered(typeof(User))) return;
        BsonClassMap.RegisterClassMap<User>(cp =>
        {
            cp.AutoMap();
            cp.MapMember(c => c.UserId)
                .SetElementName("UserId")
                .SetSerializer(new UInt64Serializer(BsonType.Int64, new RepresentationConverter(true, false)))
                .SetIsRequired(true);
            cp.MapMember(c => c.TelegramId)
                .SetElementName("TelegramId")
                .SetSerializer(new UInt64Serializer(BsonType.Int64, new RepresentationConverter(true, false)))
                .SetIsRequired(false);
            cp.MapMember(c=>c.DiscordName)
                .SetElementName("DiscordName")
                .SetIgnoreIfNull(true)
                .SetIsRequired(false);
            cp.MapMember(c => c.TelegramName)
                .SetElementName("TelegramName")
                .SetIgnoreIfNull(true)
                .SetIsRequired(false);

        });
    }
}