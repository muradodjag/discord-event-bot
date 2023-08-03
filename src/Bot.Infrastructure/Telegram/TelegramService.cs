
using Bot.Infrastructure.Interfaces.Telegram;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Infrastructure.Telegram;

public class TelegramService : ITelegramService
{
    protected readonly TelegramBotClient _client;
    public TelegramService(IConfiguration configuration)
    {
        _client = new TelegramBotClient(configuration["TELEGRAM:BOT_TOKEN"]);
    }
    public async Task<bool> SendMessage(string msg)
    {
        Message sentMessage = await _client.SendTextMessageAsync(-1001299519078, msg);
        if (sentMessage != null && sentMessage.MessageId > 0)
        {
            return true;
        }

        return false;
    }
}