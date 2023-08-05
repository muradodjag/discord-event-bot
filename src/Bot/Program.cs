using System.Reflection;
using Bot.Configurations;
using Bot.Discord.Commons;
using Bot.Infrastructure.Extensions;
using Bot.Infrastructure.Interfaces.Telegram;
using Bot.Infrastructure.Telegram;
using Color_Chan.Discord.Extensions;
using Serilog;

namespace Bot;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            var host = CreateHostBuilder(args).Build();

            var configuration = host.Services.GetRequiredService<IConfiguration>();
            var discordSocketService = host.Services.GetRequiredService<IDiscordService>();
            SerilogConfig.Configure(configuration);

            Log.Information("Starting Bot web host");
            await discordSocketService.StartAsync(configuration["DISCORD__BOT_TOKEN"]).ConfigureAwait(false);
            await host.RegisterSlashCommandsAsync(Assembly.Load("Bot.Discord")).ConfigureAwait(false);
            await host.RunAsync().ConfigureAwait(false);

            

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .UseSerilog()
                   
                   .ConfigureLogging(logging =>
                   {
                       logging.ClearProviders();
                       logging.AddSerilog();
                   })
                   .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}