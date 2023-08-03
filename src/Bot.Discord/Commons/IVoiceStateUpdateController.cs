using Discord.WebSocket;

namespace Bot.Discord.Commons;

public interface IVoiceStateUpdateController
{
    Task Handle(SocketUser user, SocketVoiceState before, SocketVoiceState after);
}