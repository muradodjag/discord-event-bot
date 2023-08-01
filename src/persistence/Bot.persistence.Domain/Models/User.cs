namespace Bot.persistence.Domain.Models;

public class User : BaseDocument
{
    /// <summary>
    /// The user id.
    /// </summary>
    public ulong UserId { get; set; }
    
    /// <summary>
    /// The user's telegram id.
    /// </summary>
    public ulong TelegramId { get; set; }
    
    /// <summary>
    /// Discord userName
    /// </summary>
    public string DiscordName { get; set; }
    
    /// <summary>
    /// Telegram userName
    /// </summary>
    public string TelegramName { get; set; }
}