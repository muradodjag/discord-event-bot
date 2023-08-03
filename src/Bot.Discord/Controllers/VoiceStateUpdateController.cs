using Bot.Discord.Commons;
using Bot.Infrastructure.Telegram;
using Bot.persistence.Domain.Models;
using Bot.persistence.UnitOfWorks;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Bot.Discord.Controllers;

public class VoiceStateUpdateController : IVoiceStateUpdateController
{
    private readonly TelegramService _telegramService;
    private readonly IUnitOfWork _unitOfWork;

    public VoiceStateUpdateController(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _telegramService = new TelegramService(configuration);
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SocketUser user, SocketVoiceState before, SocketVoiceState after)
    {
        string message = "someone has joined to voice channel";
        if ((before.VoiceChannel == null && after.VoiceChannel != null) ||
            (before.VoiceChannel != null && after.VoiceChannel != null))
        {
            // The user has joined a voice channel

                var res = await _unitOfWork.Users.GetOrAddUserAsync(user.Id, user.Username).ConfigureAwait(false);
                if (res.TelegramId != 0)
                {
                    message =
                        $"User [{res.TelegramName}](tg://user?id={res.TelegramId}) has joined to the {after.VoiceChannel.Name} voice channel.";
                    //await _telegramService.SendMessage(message);
                }
                else
                {
                    message = $"{res.DiscordName} was joined to voice channel";
                }
        }
        else
        {
            var res = await _unitOfWork.Users.GetOrAddUserAsync(user.Id, user.Username).ConfigureAwait(false);
                if (res.TelegramId != 0)
                {
                    message =
                        $"User [{res.TelegramName}](tg://user?id={res.TelegramId}) has left {before.VoiceChannel.Name} voice channel.";
                }
                else
                {
                    message = $"{res.DiscordName} was joined to voice channel";
                }
        }
        await _telegramService.SendMessage(message);
    }
}
