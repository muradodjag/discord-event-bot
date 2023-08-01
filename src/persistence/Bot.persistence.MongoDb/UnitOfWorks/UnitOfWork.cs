using Bot.persistence.Repositories;
using Bot.persistence.UnitOfWorks;

namespace Bot.persistence.MongoDb.UnitOfWorks;

/// <inheritdoc />
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IRequestsRepository requestsRepository, IDailyStatsRepository dailyStatsRepository, IServerRepository serverRepository, IUserRepository userRepository)
    {
        Requests = requestsRepository;
        DailyStats = dailyStatsRepository;
        Servers = serverRepository;
        Users = userRepository;
    }

    /// <inheritdoc />
    public IRequestsRepository Requests { get; }

    /// <inheritdoc />
    public IDailyStatsRepository DailyStats { get; }

    /// <inheritdoc />
    public IServerRepository Servers { get; }
    public IUserRepository Users { get; }
}