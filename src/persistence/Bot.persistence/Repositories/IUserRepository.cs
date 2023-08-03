using Bot.persistence.Domain.Models;

namespace Bot.persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    ///     Get a <see cref="User" /> from the table/collection.
    /// </summary>
    /// <param name="id">The Id of the guild that you want get.</param>
    /// <returns>
    ///     A task that represents the asynchronous get operation.
    ///     The task result contains the requested <see cref="User" />.
    /// </returns>
    Task<User> GetUserAsync(ulong id);

    /// <summary>
    ///     Get or add a <see cref="User" /> from the table/collection.
    /// </summary>
    /// <param name="id">The Id of the guild that you want get.</param>
    /// <param name="discordName">Name of discord user</param>
    /// <param name="telegramId">User's telegram id</param>
    /// <param name="telegramName">User's telegram name</param>
    
    /// <returns>
    ///     A task that represents the asynchronous get or add operation.
    ///     The task result contains the requested <see cref="User" />.
    /// </returns>

    Task<User> GetOrAddUserAsync(ulong id, string discordName);
}