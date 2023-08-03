using Bot.Discord.Commons;
using Discord;
using Discord.WebSocket;

namespace Bot.Discord.Services;

public class DiscordService : IDiscordService
{
    private readonly DiscordSocketClient _client;
    private readonly IVoiceStateUpdateController _voiceStateUpdateController;
    public DiscordService(IVoiceStateUpdateController voiceStateUpdateController)
    {
        _voiceStateUpdateController = voiceStateUpdateController;
        _client = new DiscordSocketClient();
        _client.UserVoiceStateUpdated += VoiceStateUpdated;
    }

    private async Task VoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
    {
        await _voiceStateUpdateController.Handle(user, before, after);
    }

    public async Task StartAsync(string token)
    {
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
    }
}