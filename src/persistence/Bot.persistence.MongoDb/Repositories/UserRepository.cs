using Bot.persistence.Domain.Models;
using Bot.persistence.Repositories;
using MongoDB.Driver;

namespace Bot.persistence.MongoDb.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IMongoCollection<User> _mongoCollection;

    /// <summary>
    ///     Creates a new <see cref="ServerRepository" />.
    /// </summary>
    /// <param name="context">The <see cref="MongoContext" /> that will be used to query to the database.</param>
    public UserRepository(MongoContext context) : base(context, nameof(User) + "s")
    {
        _mongoCollection = context.GetCollection<User>(nameof(User) + "s");
    }

    /// <inheritdoc />
    public Task<User> GetUserAsync(ulong id)
    {
        return _mongoCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<User> GetOrAddUserAsync(ulong id, string discordName,ulong? telegramId, string? telegramName)
    {
        var result = await _mongoCollection.Find(x => x.UserId == id).FirstOrDefaultAsync().ConfigureAwait(false);
        if (result is not null) return result;
        await AddAsync(new User
        {
            UserId = id,
            DiscordName = discordName,
            TelegramId = 0,
            TelegramName = "unknown"
        }).ConfigureAwait(false);
        return await _mongoCollection.Find(x => x.UserId == id).FirstOrDefaultAsync().ConfigureAwait(false);
    }
}