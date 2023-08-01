using Bot.Infrastructure.Interfaces.Telegram;
using Bot.Infrastructure.Telegram;
using Microsoft.Extensions.DependencyInjection;


namespace Bot.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddScoped<ITelegramService, TelegramService>();
    }
}