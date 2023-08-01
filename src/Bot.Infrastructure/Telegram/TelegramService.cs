
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
        _client = new TelegramBotClient(configuration["BOT_TELEGRAM_TOKEN"]);
    }
    public async Task SendMessage(string msg)
    {
        Message sentMessage = await _client.SendTextMessageAsync(-1001299519078, msg);
    }
}