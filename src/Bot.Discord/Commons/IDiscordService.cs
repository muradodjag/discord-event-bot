namespace Bot.Discord.Commons;

public interface IDiscordService
{
    Task StartAsync(string token);
}