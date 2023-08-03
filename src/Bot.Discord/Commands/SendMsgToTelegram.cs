using Bot.Infrastructure.Interfaces.Telegram;
using Bot.Infrastructure.Telegram;
using Color_Chan.Discord.Commands.Attributes;
using Color_Chan.Discord.Commands.Attributes.ProvidedRequirements;
using Color_Chan.Discord.Commands.MessageBuilders;
using Color_Chan.Discord.Commands.Modules;
using Color_Chan.Discord.Core.Common.Models.Interaction;
using Color_Chan.Discord.Core.Results;
using Microsoft.Extensions.Configuration;

namespace Bot.Discord.Commands;

[SlashCommandGroup("telegram", "Command for the interaction with telegram")]
[UserRateLimit(5, 10)]
public class SendMsgToTelegram : SlashCommandModule
{
    private readonly TelegramService _telegramService;

    public SendMsgToTelegram(IConfiguration configuration)
    {
        _telegramService = new TelegramService(configuration);
    }
    public const string SendMsgCommandName = "sendmsg";
    public const string SendMsgCommandDesc = "Send message to telegram channel";
    
    [SlashCommand(SendMsgCommandName, SendMsgCommandDesc)]
    public async  Task<Result<IDiscordInteractionResponse>> SendMsgAsync
    (
        [SlashCommandOption("text", "The text that will be returned.", true)]
        string text
    )
    {
        bool result =  await _telegramService.SendMessage(text);
        if (result)
        {
            return  FromSuccess("Your message was sent");
        }

        return FromError("Your message wasn't sent");

        // Build the embedded response.

    }
}