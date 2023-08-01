namespace Bot.Infrastructure.Interfaces.Telegram;

public interface ITelegramService
{
    /// <summary>
    /// Send message to telegram channel
    /// </summary>
    /// <param name="msg"> Message which we send to channel</param>
    /// <returns></returns>
    Task SendMessage(string msg);
}